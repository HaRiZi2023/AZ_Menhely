using Google.Protobuf.WellKnownTypes;
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
         
            /* gomb megjelenítés választás alapjánhoz
            button_GuestInsert.Visible = true;
            button_GuestUpdate.Visible = false;
            button_GuestDelete.Visible = false;
            */



            //this.selectedGuest = selectedGuest;

            //uploadData();



            
            //listBox_Choice.SelectedIndexChanged += listBox_Choice_SelectedIndexChanged; // Ez a sor fontos

        }

        public FormGuest(Guest selectedGuest)
        {
            InitializeComponent();
            this.selectedGuest = selectedGuest;

            /* gomb megjelenítés választás alapjánhoz
           if (selectedGuest != null)
            {
                button_GuestInsert.Visible = false;
                button_GuestUpdate.Visible = true;
                button_GuestDelete.Visible = true;
                uploadData();
            }
            else
            {
                button_GuestInsert.Visible = true;
                button_GuestUpdate.Visible = false;
                button_GuestDelete.Visible = false;
            }
            */


            uploadData();
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {

            /*
                    this.Text = "Felvitel";
                    button_GuestInsert.Text = "Felvitel";
                    button_GuestInsert.Visible = true;
                    //button_GuestInsert.Click += new EventHandler(insertGuest);
            */
           
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
                //dateTimePicker_GuestIn.Value = DateTimeOffset.Parse(selectedGuest.G_in_date).DateTime;
                
                //dateTimePicker_GuestOut.Value = DateTime.Parse(selectedGuest.G_out_date).ToLocalTime;
                richTextBox_GuestOther.Text = selectedGuest.G_other;

                if (selectedGuest.G_image != null && selectedGuest.G_image.Length > 0)
                {
                    try
                    {/*
                        // MemoryStream létrehozása a byte tömbből
                        using (MemoryStream ms = new MemoryStream(selectedGuest.G_image))
                        {
                            // Kép betöltése a MemoryStream-ből
                            pictureBox_GuestImage.Image = Image.FromStream(ms);
                        }*/
                    }
                    catch (Exception ex)
                    {
                        // Ha a kép betöltése nem sikerült, jelenítsünk meg egy hibaüzenetet
                        MessageBox.Show($"Nem sikerült betölteni a képet: listbox select{ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Ha a kép üres vagy null értékű, akkor töröljük a pictureBox tartalmát
                    pictureBox_GuestImage.Image = null;
                    // Esetlegesen itt megjeleníthetünk egy üzenetet, hogy nincs kép
                }


                /*
                if (selectedfound.F_image != null && selectedfound.F_image.Length > 0)
                {
                    try
                    {
                        // MemoryStream létrehozása a byte tömbből
                        using (MemoryStream ms = new MemoryStream(selectedfound.F_image))
                        {
                            // Kép betöltése a MemoryStream-ből
                            pictureBox_FoundImage.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ha a kép betöltése nem sikerült, jelenítsünk meg egy hibaüzenetet
                        MessageBox.Show($"Nem sikerült betölteni a képet: listbox select{ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Ha a kép üres vagy null értékű, akkor töröljük a pictureBox tartalmát
                    pictureBox_FoundImage.Image = null;
                    // Esetlegesen itt megjeleníthetünk egy üzenetet, hogy nincs kép
                }*/


                /*
                if (!string.IsNullOrEmpty(selectedGuest.G_image))  // G_imageBase64!
                {
                    try
                    {
                        byte[] imageData = Convert.FromBase64String(selectedGuest.G_image); // G_imageBase64!
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox_GuestImage.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba a kép megjelenítésekor: " + ex.Message);
                    }
                }*/
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
        
        /**** új *****/





        /*
        public byte[] ImageToByteArray(Image imageIn) // Kép byte tömbbé alakítása
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArray) // Byte tömb visszaalakítása képpé
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public void InsertImage(byte[] imageBytes) // Adatbázisba történő képmentés
        {
            // Itt meg kell hívni az adatbázisba történő mentés logikáját, például SQL INSERT parancsot
        }

        public byte[] ReadImageFromDatabase() // Adatbázisból történő képolvasás
        {
            // Itt meg kell hívni az adatbázisból történő olvasás logikáját, például SQL SELECT parancsot
            // Eredményként kapott byte tömböt vissza kell adni
            //return byteArrayFromDatabase;
        }
        */
        /***********  képek <- ***********/



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

                 if (pictureBox_GuestImage.Image != null)  // kéne else
                 {
                    //guest.G_image = ImageToByteArray(pictureBox_GuestImage.Image);
                 }
                /*
                else  // ez is nullát ad vissza
                {
                    pictureBox_GuestImage.Image = Properties.Resources.logo; 
                }
                */
                /*
                else  //se Resources/Picture.png  se Guest_Images/Picture.png se Solution Items/DefultImage.png
                {
                    // Alapértelmezett kép beállítása, ha nincs másik kép
                    string defaultImagePath = "Guest_Images/Picture.png"; // Adjuk meg az alapértelmezett kép elérési útját
                    guest.G_image = File.ReadAllBytes(defaultImagePath);
                }*/

                guest.Created_at = DateTime.Now;
                guest.Updated_at = DateTime.Now;





                //database.insertGuest(guest);
                MessageBox.Show("A kép sikeresen mentve lett az adatbázisba!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a kép mentése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

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
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox_GuestImage.Image.Save(ms,           pictureBox_GuestImage.Image.RawFormat);
                        //selectedGuest.G_image = ms.ToArray() ;
                    }

                    

                    // A módosítás idejét frissítjük
                    selectedGuest.Updated_at = DateTime.Now;

                    //database.updateGuest(selectedGuest);
                    MessageBox.Show("A vendég adatai frissítve lettek!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_GuestDelete_Click(object sender, EventArgs e)// G_imageBase64!
        {

            if (selectedGuest != null)
            {
                //database.deleteGuest(selectedGuest);
                MessageBox.Show("A vendég sikeresen törölve lett az adatbázisból!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
