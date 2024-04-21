using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using Newtonsoft.Json;
using System.Drawing.Imaging;

namespace AZ_Desktop
{
    public partial class FormFound : Form
    {
        HttpClient client = new HttpClient();
        string endPoint = ReadSetting("endpointUrl");
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private static string ReadSetting(string keyName) // RR 
        {
            string result = null;
            try
            {
                var value = ConfigurationManager.AppSettings;
                result = value[keyName];
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public FormFound() 
        {
            InitializeComponent();            
        }

        private void FormFound_Load(object sender, EventArgs e) // allFoundlist()
        {
            allFoundList();
            listView_Found.FullRowSelect = true; //  egész sor jelölve legyen
            //pictureBox_FoundImage.InitialImage = Image.FromFile(Application.StartupPath + "\\DefaultImage.png");
        }


        /*****************************/

        private void emptyFieldsFound()  // mezők kiürítése 
        {
            pictureBox_FoundImage.Image = null;
            listView_Found.Items.Clear();

            textBox_FoundChoice.Text = "";
            textBox_FoundSpecies.Text = "";
            textBox_FoundGender.Text = "";

            textBox_FoundWhere.Text = "";
            textBox_FoundInjury.Text = "";
            richTextBox_FoundOther.Text = "";

        }

        private async void allFoundList() //0417 ok
        {
            listView_Found.Items.Clear();
            var response = await client.GetAsync($"{endPoint}/founds");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var founds = JsonConvert.DeserializeObject<List<Found>>(data);
                foreach (var found in founds)
                {
                    var item = new ListViewItem(new[] { found.Id.ToString(), found.F_choice, found.F_species });
                    item.Tag = found;
                    listView_Found.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Nem sikerült betölteni az adatokat!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_Found_SelectedIndexChanged(object sender, EventArgs e) //0419
        {
            
            if (listView_Found.SelectedItems.Count > 0)
            {
                var selectedItem = listView_Found.SelectedItems[0];
                var selectedFound = (Found)selectedItem.Tag;

                // Feltöltjük a vezérlőket a kiválasztott Found objektum adataival

                textBox_FoundId.Text = selectedFound.Id.ToString();
                textBox_FoundChoice.Text = selectedFound.F_choice;
                textBox_FoundSpecies.Text = selectedFound.F_species;
                textBox_FoundGender.Text = selectedFound.F_gender;
                textBox_FoundWhere.Text = selectedFound.F_position;
                textBox_FoundInjury.Text = selectedFound.F_injury;
                richTextBox_FoundOther.Text = selectedFound.F_other;


                pictureBox_FoundImage.Image = Base64ToImage(selectedFound.F_image) ?? pictureBox_FoundImage.InitialImage;
                
            }
        }
        //*** kép **//
        private Image Base64ToImage(string base64String) //0419 megj
        {
            if (string.IsNullOrEmpty(base64String)) //Ha nulla a kép
            {
                return null; // vagy visszatérhet egy alapértelmezett képpel
            }

            // Dekódolja a Base64 stringet byte tömbbé
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Hozzon létre egy MemoryStream-t a byte tömbből
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Átalakítja a byte tömböt Image objektummá
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private string ImageToBase64(Image image) //0419 felv
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Mentse el a képet a MemoryStream-ba
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Konvertálja a MemoryStream tartalmát byte tömbbé
                byte[] byteImage = ms.ToArray();

                // Konvertálja a byte tömböt Base64 stringgé
                string base64String = Convert.ToBase64String(byteImage);
                return base64String;
            }
        }
        
        //*** kép **//
        private void button_FoundUpdate_Click(object sender, EventArgs e)   //0419
        {
                       // minden kötelező mező kitöltve van-e
            if (!string.IsNullOrEmpty(textBox_FoundGender.Text) &&
                !string.IsNullOrEmpty(textBox_FoundInjury.Text))
            {
                // van-e kiválasztott elem a ListView-ban
                if (listView_Found.SelectedItems.Count > 0)
                {
                    Found selectedFound = new Found();

                    var json = JsonConvert.SerializeObject(selectedFound); //-- továbbítandó adat
                    var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                    string endPointUpdate = $"{endPoint}/found/{selectedFound.Id}";
                    var response = client.PutAsync(endPointUpdate, data).Result;
                    if (response.IsSuccessStatusCode)

                        // Hozzon létre egy Found objektumot az űrlap adataiból
                    selectedFound.Id = long.Parse(textBox_FoundId.Text);
                    selectedFound.F_choice = textBox_FoundChoice.Text;
                    selectedFound.F_species = textBox_FoundSpecies.Text;
                    selectedFound.F_gender = textBox_FoundGender.Text;
                    selectedFound.F_injury = textBox_FoundInjury.Text;
                    selectedFound.F_position = textBox_FoundWhere.Text;
                    selectedFound.F_other = richTextBox_FoundOther.Text;

                    if (pictureBox_FoundImage.Image != null)
                    {
                        selectedFound.F_image = ImageToBase64(pictureBox_FoundImage.Image);
                    }

                    selectedFound.Updated_at = DateTime.Now;

                    // Üres mezők
                    emptyFieldsFound();

                    // ListView újra
                    allFoundList();

                    MessageBox.Show("Sikeres adat frissítés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nincs kiválasztott elem a ListView-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nem minden kötelező mező van kitöltve!", "Hiányzó adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
                     
        private void button_FoundDelete_Click(object sender, EventArgs e) //0419 ok
        {
            // van-e kiválasztott elem a ListView-ban
            if (listView_Found.SelectedItems.Count > 0)
            {
                var selectedItem = listView_Found.SelectedItems[0];
                var selectedFound = (Found)selectedItem.Tag;

                if (MessageBox.Show("Valóban törölni szeretné?") == DialogResult.OK)
                {
                    string endPointDelete = $"{endPoint}/founds/{selectedFound.Id}";
                    var response = client.DeleteAsync(endPointDelete).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Ürítsd ki a mezőket
                        emptyFieldsFound();

                        // Töltsd újra a ListView-t
                        allFoundList();

                        // Felhasználói visszajelzés a sikeres törlésről
                        MessageBox.Show("Sikeres adat törlés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült törölni az adatot!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListView-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

