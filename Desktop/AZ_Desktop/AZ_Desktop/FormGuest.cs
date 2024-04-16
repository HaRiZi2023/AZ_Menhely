using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace AZ_Desktop
{
    
    public partial class FormGuest : Form
    {
        private Guest selectedGuest;
        private string _action;

        HttpClient client = new HttpClient();
        string endPoint = ReadSetting("endpointUrl");

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

        public FormGuest()
        {
            InitializeComponent();
            this._action = "Default"; // alapért.műv.
            //uploadData();
            //listBox_Choice.SelectedIndexChanged += listBox_Choice_SelectedIndexChanged; // Ez a sor fontos

        }

        public FormGuest(Guest guest)
        {
            InitializeComponent();
            this.selectedGuest = guest;
            this._action = "Default"; // alapért. műv.
            //uploadData();
        }

        public FormGuest(Guest guest, string action)
        {
            InitializeComponent();
            this.selectedGuest = selectedGuest; 
            this._action = action;
                       
            uploadData();
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {
            switch (_action)
            {
                case "Insert":
                    button_GuestInsert.Visible = true;
                    button_GuestUpdate.Visible = false;
                    button_GuestDelete.Visible = false;
                    break;
                case "Update":
                    button_GuestInsert.Visible = false;
                    button_GuestUpdate.Visible = true;
                    button_GuestDelete.Visible = false;
                    break;
                case "Delete":
                    button_GuestInsert.Visible = false;
                    button_GuestUpdate.Visible = false;
                    button_GuestDelete.Visible = true;
                    break;
            }
        }

        public void uploadData()   // adat feltöltése () üres upload ---  // A felület feltöltése a kiválasztott vendég adataival   
        {
            if (selectedGuest != null)
            {
                textBox_GuestName.Text = selectedGuest.G_name;
                textBox_GuestChip.Text = selectedGuest.G_chip;
                textBox_GuestWhere.Text = selectedGuest.G_in_place;
                comboBox_GuestSpecies.Text = selectedGuest.G_species;
                comboBox_GuestGender.Text = selectedGuest.G_gender;
                comboBox_GuestAdoption.Text = selectedGuest.G_adoption;
                dateTimePicker_GuestIn.Value = selectedGuest.G_in_date.DateTime;
                
                dateTimePicker_GuestOut.Value = selectedGuest.G_out_date.DateTime;
                richTextBox_GuestOther.Text = selectedGuest.G_other;

                if (selectedGuest.G_image != null && selectedGuest.G_image.Length > 0)
                {
                    try
                    {
                        // kép
                    }
                    catch { }
                }
            }
        }

        /******** validálás mező ///  üressé tétele *********/

        private bool validateInputGuest() //inserthez + üres konstruktor guestben!
        {
            if (string.IsNullOrEmpty(textBox_GuestName.Text) ||
                string.IsNullOrEmpty(textBox_GuestWhere.Text) ||
                string.IsNullOrEmpty(comboBox_GuestSpecies.Text)|| 
                string.IsNullOrEmpty(comboBox_GuestGender.Text) ||
                string.IsNullOrEmpty(comboBox_GuestAdoption.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = textBox_GuestName;  // fokusz ide!

                return false;
            }
            return true;
        }

        private void emptyFieldsGuest()  // mezők kiürítése kell-e??
        {
            textBox_GuestName.Text = "";
            textBox_GuestId.Text = "";
            textBox_GuestChip.Text = "";
            textBox_GuestWhere.Text = "";
            comboBox_GuestSpecies.Text = "";
            comboBox_GuestGender.Text = "";
            comboBox_GuestAdoption.Text = "";
            dateTimePicker_GuestIn.Value = DateTime.Now;
            dateTimePicker_GuestOut.Value = DateTime.Now;
            richTextBox_GuestOther.Text = "";
        }

        /***********  képek -> ***********/


        private void loadImage(byte[] imageData)  // vagy selectedGuest.G_image byte helyett
        {
            if (imageData != null && imageData.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox_GuestImage.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A kép megjelenítése sikertelen: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Ha az imageData null vagy üres, betöltjünk egy alapértelmezett képet
                pictureBox_GuestImage.Image = Properties.Resources.logo; // Ez feltételezi, hogy az alapértelmezett kép a projektben elérhető erőforrás
            }
        }
        /********* nem kell  ***************/
        /*
         private byte[] ImageToByteArray(Image imageIn)
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 imageIn.Save(ms, imageIn.RawFormat);
                 return ms.ToArray();
             }
         }

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
        /********* nem kell  ***************/

        private void pictureBox_GuestImage_Click(object sender, EventArgs e)  // kép kiválasztása pictureboxon keresztül
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp, *.bin)|*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.bin";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_GuestImage.Image = new Bitmap(dialog.FileName);
               // selectedImagePath = dialog.FileName;
            }
        }

        /********** gombok *************/


        
        private void button_GuestInsert_Click(object sender, EventArgs e)
        {
            if (pictureBox_GuestImage.Image == null)
            {
                MessageBox.Show("Nincs kiválasztott kép!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Image image = pictureBox_GuestImage.Image;
                Guest guest = new Guest
                {
                    G_name = textBox_GuestName.Text,
                    G_chip = textBox_GuestChip.Text,
                    G_in_place = textBox_GuestWhere.Text,
                    G_species = comboBox_GuestSpecies.Text,
                    G_gender = comboBox_GuestGender.Text,
                    G_adoption = comboBox_GuestAdoption.Text,
                    G_in_date = dateTimePicker_GuestIn.Value,
                    G_out_date = dateTimePicker_GuestOut.Value,
                    G_other = richTextBox_GuestOther.Text,
                };
                    //G_image = pictureBox_GuestImage.Image,

                    // G_image = ImageToByteArray(pictureBox_GuestImage.Image),

                    // Kép beolvasása és konvertálása byte tömbbé

                 if (pictureBox_GuestImage.Image != null && selectedGuest.G_image.Length > 0)  // kéne else
                 { /* legutolsó nem jó image string <-> int
                    using (var ms = new MemoryStream(selectedGuest.G_image))
                    {
                        // A kép beállítása a PictureBox vezérlő Image tulajdonságában
                        pictureBox_GuestImage.Image = Image.FromStream(ms);
                    }*/
                 }  

                 guest.Created_at = DateTime.Now;
                 guest.Updated_at = DateTime.Now;
                                    
                MessageBox.Show("A kép sikeresen mentve lett az adatbázisba!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a kép mentése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        //uploadData() induláskor betölt!!!! eleje nem kell!
        private void button_GuestUpdate_Click(object sender, EventArgs e)// 
        {
            if (validateInputGuest()) // Ellenőrizzük, hogy minden kötelező mező kitöltve van-e
            {
                if (selectedGuest != null)
                {
                    selectedGuest.G_name = textBox_GuestName.Text;
                    selectedGuest.G_chip = textBox_GuestChip.Text;
                    selectedGuest.G_in_place = textBox_GuestWhere.Text;
                    selectedGuest.G_species = comboBox_GuestSpecies.Text;
                    selectedGuest.G_gender = comboBox_GuestGender.Text;
                    selectedGuest.G_adoption = comboBox_GuestAdoption.Text;
                    selectedGuest.G_in_date = dateTimePicker_GuestIn.Value;
                    selectedGuest.G_out_date = dateTimePicker_GuestOut.Value;
                    selectedGuest.G_other = richTextBox_GuestOther.Text;
                    // A módosítás idejét frissítjük
                    selectedGuest.Updated_at = DateTime.Now; // ????

                    using (MemoryStream ms = new MemoryStream())
                    { /*
                        pictureBox_GuestImage.Image.Save(ms,           pictureBox_GuestImage.Image.RawFormat);
                        //selectedGuest.G_image = ms.ToArray() ; */
                    }


                    Guest guest = new Guest();

                    guest.Id = long.Parse(textBox_GuestId.Text);

                    selectedGuest.G_name = textBox_GuestName.Text;
                    selectedGuest.G_chip = textBox_GuestChip.Text;
                    selectedGuest.G_in_place = textBox_GuestWhere.Text;
                    selectedGuest.G_species = comboBox_GuestSpecies.Text;
                    selectedGuest.G_gender = comboBox_GuestGender.Text;
                    selectedGuest.G_adoption = comboBox_GuestAdoption.Text;
                    //selectedGuest.G_in_date = dateTimePicker_GuestIn.Value.ToString();
                    selectedGuest.G_out_date = dateTimePicker_GuestOut.Value;
                    selectedGuest.G_other = richTextBox_GuestOther.Text;
                    // A módosítás idejét frissítjük
                    selectedGuest.Updated_at = DateTime.Now;



                    var json = JsonConvert.SerializeObject(guest); //-- továbbítandó adat
                    var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                    string endPointUpdate = $"{endPoint}/{guest.Id}";
                    var response = client.PutAsync(endPointUpdate, data).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("A vendég adatai frissítve lettek!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //uploadData() induláskor betölt!!!! eleje nem kell!
        private void button_GuestDelete_Click(object sender, EventArgs e)// G_imageBase64!
        {
            if (validateInputGuest()) // Ellenőrizzük, hogy minden kötelező mező kitöltve van-e
            {
                selectedGuest.G_name = textBox_GuestName.Text;
                selectedGuest.G_chip = textBox_GuestChip.Text;
                selectedGuest.G_in_place = textBox_GuestWhere.Text;
                selectedGuest.G_species = comboBox_GuestSpecies.Text;
                selectedGuest.G_gender = comboBox_GuestGender.Text;
                selectedGuest.G_adoption = comboBox_GuestAdoption.Text;
                selectedGuest.G_in_date = dateTimePicker_GuestIn.Value;
                selectedGuest.G_out_date = dateTimePicker_GuestOut.Value;
                selectedGuest.G_other = richTextBox_GuestOther.Text;
                // A módosítás idejét frissítjük
                selectedGuest.Updated_at = DateTime.Now;  ///?????

                using (MemoryStream ms = new MemoryStream())
                { /*
                        pictureBox_GuestImage.Image.Save(ms,           pictureBox_GuestImage.Image.RawFormat);
                        //selectedGuest.G_image = ms.ToArray() ; */
                }

                if (MessageBox.Show("Valóban törölni szeretné?") == DialogResult.OK)
                {
                    Guest guest = new Guest();

                    guest.Id = long.Parse(textBox_GuestId.Text);
                    //string endPointDelete = $"{endPoint}/{guest.Id}";


                    selectedGuest.G_name = textBox_GuestName.Text;
                    selectedGuest.G_chip = textBox_GuestChip.Text;
                    selectedGuest.G_in_place = textBox_GuestWhere.Text;
                    selectedGuest.G_species = comboBox_GuestSpecies.Text;
                    selectedGuest.G_gender = comboBox_GuestGender.Text;
                    selectedGuest.G_adoption = comboBox_GuestAdoption.Text;
                    //selectedGuest.G_in_date = dateTimePicker_GuestIn.Value.ToString();
                    selectedGuest.G_out_date = dateTimePicker_GuestOut.Value;
                    selectedGuest.G_other = richTextBox_GuestOther.Text;
                    // A módosítás idejét frissítjük
                    selectedGuest.Deleted_at = DateTime.Now;



                    // softdelete!!!!!

                    string endPointDelete = $"{endPoint}/{guest.Id}";
                    var response = client.DeleteAsync(endPointDelete).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("A vendég sikeresen törölve lett az adatbázisból!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //listafrissitese();
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen törlés!");
                    }

                    MessageBox.Show("A vendég sikeresen törölve lett az adatbázisból!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
