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

        private async void LoadImage(long id)
        {
            var response = await client.GetAsync($"{endPoint}/founds/{id}/image");
            if (response.IsSuccessStatusCode)
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                using (var ms = new MemoryStream(bytes))
                {
                    pictureBox_FoundImage.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("Nem sikerült betölteni a képet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_Found_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView_Found.SelectedItems.Count > 0)
            {
                var selectedItem = listView_Found.SelectedItems[0];
                var selectedFound = (Found)selectedItem.Tag;

                // Feltöltjük a vezérlőket a kiválasztott Found objektum adataival
                pictureBox_FoundImage.Text = selectedFound.F_image;
                textBox_FoundId.Text = selectedFound.Id.ToString();
                textBox_FoundChoice.Text = selectedFound.F_choice;
                textBox_FoundSpecies.Text = selectedFound.F_species;
                textBox_FoundGender.Text = selectedFound.F_gender;
                textBox_FoundWhere.Text = selectedFound.F_position;
                textBox_FoundInjury.Text = selectedFound.F_injury;
                richTextBox_FoundOther.Text = selectedFound.F_other;

                LoadImage(selectedFound.Id);

            }
        }


    
        /*
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        */
        /*
        private string ImageToBase64(Image image)// G_imageBase64!
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        */
        private void button_FoundUpdate_Click(object sender, EventArgs e)   
        {
                       // minden kötelező mező kitöltve van-e
            if (!string.IsNullOrEmpty(textBox_FoundGender.Text) &&
                !string.IsNullOrEmpty(textBox_FoundInjury.Text) &&
                !string.IsNullOrEmpty(richTextBox_FoundOther.Text))
            {
                // van-e kiválasztott elem a ListView-ban
                if (listView_Found.SelectedItems.Count > 0)
                {
                    Found selectedFound = new Found();

                    var json = JsonConvert.SerializeObject(selectedFound); //-- továbbítandó adat
                    var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                    string endPointUpdate = $"{endPoint}/{selectedFound.Id}";
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

                    selectedFound.Updated_at = DateTime.Now;
                    /*
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox_FoundImage.Image = new Bitmap(openFileDialog1.FileName);
                        selectedFound.F_image = File.ReadAllBytes(openFileDialog1.FileName);
                    }
                    */
                 
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
                     
        private void button_FoundDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Valóban törölni szeretné?") == DialogResult.OK)
            {
                // van-e kiválasztott elem a ListView-ban
                if (listView_Found.SelectedItems.Count > 0)
                {
                    Found selectedFound = new Found();
                   
                        //  egy új Found objektumot az űrlap adataiból
                    selectedFound.Id = long.Parse(textBox_FoundId.Text);
                    selectedFound.F_choice = textBox_FoundChoice.Text;
                    selectedFound.F_species = textBox_FoundSpecies.Text;
                    selectedFound.F_gender = textBox_FoundGender.Text;
                    selectedFound.F_injury = textBox_FoundInjury.Text;
                    selectedFound.F_position = textBox_FoundWhere.Text;
                    selectedFound.F_other = richTextBox_FoundOther.Text;

                    selectedFound.Updated_at = DateTime.Now;


                    string endPointDelete = $"{endPoint}/{selectedFound.Id}";
                    var response = client.DeleteAsync(endPointDelete).Result;
                    if (response.IsSuccessStatusCode)
                        /*
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            pictureBox_FoundImage.Image = new Bitmap(openFileDialog1.FileName);
                            selectedFound.F_image = File.ReadAllBytes(openFileDialog1.FileName);
                        }
                        */
                        
                        // Ürítsd ki a mezőket
                        emptyFieldsFound();

                    // Töltsd újra a ListView-t
                    allFoundList();

                    // Felhasználói visszajelzés a sikeres frissítésről
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
    }
}


/****** youtubos ************/
/*
public Image ByteArrayToImage(byte[] byteArrayIn)
{
    using MemoryStream ms = new MemoryStream(byteArrayIn)
    {
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
}

public byte[] ImageToByteArray(System.Drawing.Image.imageIn) 
{
    using (MemoryStream ms = new MemoryStream())
    {
        ImageIndexConverter.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);  // felajánlott: Bmp);
        return ms.ToArray();
    }
}
*/

//****** youtubos ***********
