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
        private Guest selectedGuest; // nem kell???
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
            

        }

        public FormGuest(Guest guest)
        {
            InitializeComponent();
            this.selectedGuest = guest;
            this._action = "Default"; // alapért. műv.
            //uploadData();
        }

        public FormGuest(int id, string action)
        {
            InitializeComponent();
            //this.selectedGuest = guest; 
            this._action = action;

            InitializeAsync(id);
            uploadData();
        }

        private async void InitializeAsync(int id)
        {
            this.selectedGuest = await GetGuestById(id);
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
                    setReadOnly();
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

                pictureBox_GuestImage.Image = Base64ToImage(selectedGuest.G_image);
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
            pictureBox_GuestImage.Image = null;
        }

        private void setReadOnly() // 04.20 delnél csak olvashatóra
        {
            textBox_GuestName.ReadOnly = true;
            textBox_GuestChip.ReadOnly = true;
            textBox_GuestWhere.ReadOnly = true;
            textBox_GuestChip.ReadOnly = true;
            textBox_GuestWhere.ReadOnly = true;
            comboBox_GuestSpecies.Enabled = false;
            comboBox_GuestGender.Enabled = false;
            comboBox_GuestAdoption.Enabled = false;
            dateTimePicker_GuestIn.Enabled = false;
            dateTimePicker_GuestOut.Enabled = false;
            richTextBox_GuestOther.ReadOnly = true;
        }

        //*** kép **//
        private Image Base64ToImage(string base64String) //0419
        {
            // Dekódolja a Base64 stringet byte tömbbé
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Hozzon létre egy MemoryStream-t a byte tömbből
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Átalakítja a byte tömböt Image objektummá
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private string ImageToBase64(Image image) //0419 ez ide 
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

        public void ConvertImageToBin(string sourceDirectory) //egyébből bin
        {
            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp" };
            foreach (var extension in imageExtensions)
            {
                var files = Directory.GetFiles(sourceDirectory, extension);
                foreach (var file in files)
                {
                    var bytes = File.ReadAllBytes(file);
                    File.WriteAllBytes(Path.ChangeExtension(file, ".bin"), bytes);
                }
            }
        }

        //*** kép **//

        byte[] selectedImageBin;
        private void pictureBox_GuestImage_Click(object sender, EventArgs e)  // kép kiválasztása pictureboxon keresztül
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_GuestImage.Image = new Bitmap(dialog.FileName);
               // ez jeleníti meg a pictureboxban
            }
            selectedImageBin = File.ReadAllBytes(dialog.FileName);
        }  // először beolvassa a képfájlt byte[] -be, majdezt konvertálja base64 stringé

        /********** gombok *************/

        

        private async Task<Guest> GetGuestById(int id) // read
        {
            // Létrehozunk egy új HttpClient példányt
            //HttpClient client = new HttpClient();

            // Meghívjuk az API végpontot, ami visszaadja a vendéget az ID alapján

            HttpResponseMessage response = await client.GetAsync($"{endPoint}/guests/{id}");

            if (response.IsSuccessStatusCode)
            {
                // Ha sikeres volt a kérés, akkor a válasz tartalmát átalakítjuk Guest objektummá
                string content = await response.Content.ReadAsStringAsync();
                Guest guest = JsonConvert.DeserializeObject<Guest>(content);
                return guest;
            }
            else
            {
                // Ha nem volt sikeres a kérés, akkor null-t adunk vissza
                return null;
            }
        }

        /********** gombok *************/

        private async void button_GuestInsert_Click(object sender, EventArgs e)
        {
            if (pictureBox_GuestImage.Image == null) //0420 ok
            {
                MessageBox.Show("Nincs kiválasztott kép!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
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

                    G_image = Convert.ToBase64String(selectedImageBin), // kép Base64 formátumba konvertálására.
                };
                

                guest.Created_at = DateTime.Now;
                guest.Updated_at = DateTime.Now;

                Console.WriteLine(textBox_GuestName.Text);

                var json = JsonConvert.SerializeObject(guest);
                //
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                

                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var response = await client.PostAsync(endPoint + "/guests", data);

                //response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode+" "+response.Content.ReadAsStringAsync().Result);
                }

                MessageBox.Show("A kép és minden sikeresen mentve lett az adatbázisba!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a kép és minden mentése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        //uploadData() induláskor betölt!!!! 
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
                                        
                    // Frissítjük a képet is, ha van kiválasztva
                    if (pictureBox_GuestImage.Image != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            pictureBox_GuestImage.Image.Save(ms, pictureBox_GuestImage.Image.RawFormat);
                            selectedGuest.G_image = Convert.ToBase64String(ms.ToArray());
                        }
                    }

                    var json = JsonConvert.SerializeObject(selectedGuest); //-- továbbítandó adat
                    var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                    string endPointUpdate = $"{endPoint}/{selectedGuest.Id}";
                    var response = client.PutAsync(endPointUpdate, data).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("A vendég adatai frissítve lettek!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("NNNNNNincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //uploadData() induláskor betölt!!!! eleje nem kell!
        private async void button_GuestDelete_Click(object sender, EventArgs e)// 
        {
            if (MessageBox.Show("Valóban törölni szeretné?") == DialogResult.OK)
            {
                selectedGuest.Deleted_at = DateTime.Now;

                string endPointDelete = $"{endPoint}/guests/{selectedGuest.Id}";
                var response = await client.DeleteAsync(endPointDelete);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("A vendég sikeresen törölve lett az adatbázisból!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sikertelen törlés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Vissza a FormChoicera
            FormChoice formChoice = new FormChoice();
            formChoice.Show();
            this.Close();
        }
    }
}
