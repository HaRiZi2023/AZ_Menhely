using AZ_Desktop;
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
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AZ_Desktop
{
    
    public partial class FormAdoption : Form
    {
        HttpClient client = new HttpClient();
        string endPoint = ReadSetting("endpointUrl");
        
        private List<Guest> allAnimals;
        private List<User> allUsers;

        private static string ReadSetting(string keyName)
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


        public FormAdoption()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            allAnimals = await allAdoptableAnimal();
            allUsers = await allUser();
            uploadingAnimalName();
            uploadingUserName();
        }

        private void FormAdoption_Load(object sender, EventArgs e) 
        {
            placeholderAdoption(); // 0419 kelll Kérem válasszon!
        }

        private void uploadingAnimalName()
        {
            if (comboBox_AdoptionGName.Items.Count > 0)
                comboBox_AdoptionGName.Items.Clear();
            if (allAnimals != null && allAnimals.Count > 0)
            {
                foreach (Guest animal in allAnimals)
                {
                    if (!string.IsNullOrWhiteSpace(animal.G_name))  //Name
                        comboBox_AdoptionGName.Items.Add(animal.G_name); // Változtasd meg az állatok nevének megfelelő tulajdonságra
                }
            }
            else
            {
                MessageBox.Show("Nincs elérhető adat az állatokhoz.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uploadingUserName()
        {
            if (comboBox_AdoptionUName.Items.Count > 0)
                comboBox_AdoptionUName.Items.Clear();

            if (allUsers != null && allUsers.Count > 0)
            {
                foreach (User user in allUsers)
                {
                    if (!string.IsNullOrWhiteSpace(user.Name))
                        comboBox_AdoptionUName.Items.Add(user.Name);
                }
            }
            else
            {
                MessageBox.Show("Nincs elérhető adat a felhasználókhoz.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //***********************//

        private void placeholderAdoption()   //mező szöveg
        {
            comboBox_AdoptionGName.Text = "Kérem válasszon!";
            comboBox_AdoptionUName.Text = "Kérem válasszon!";
        }

        private void emptyFieldsAdoption()  // mezők kiürítése ok m
        {
            comboBox_AdoptionGName.Text = "";
            textBox_AdoptionSpecies.Text = "";
            textBox_AdoptionGender.Text = "";
            textBox_AdoptionChip.Text = "";
            pictureBox_AdoptionImage.Text = "";

            comboBox_AdoptionUName.Text = "";
            textBox_AdoptionAddress.Text = "";
            textBox_AdoptionEmail.Text = "";
            textBox_AdoptionPhone.Text = "";

            dateTimePicker_AdoptionDate.Value = DateTime.Now;
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

        private string ImageToBase64(Image image) //0419
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

        private void comboBox_AdoptionGName_SelectedIndexChanged(object sender, EventArgs e)   // 0419 ok textboxok feltöltése
        {
            if (comboBox_AdoptionGName.SelectedItem != null)
            {
                // választott
                string selectedAnimalName = comboBox_AdoptionGName.SelectedItem.ToString();

                // név alapján listában 
                Guest selectedAnimal = allAnimals.Find(animal => animal.G_name == selectedAnimalName);

                // Ha meg van, akkor feltöltjük a TextBoxokat
                if (selectedAnimal != null)
                {
                    textBox_AdoptionSpecies.Text = selectedAnimal.G_species;
                    textBox_AdoptionGender.Text = selectedAnimal.G_gender;
                    textBox_AdoptionChip.Text = selectedAnimal.G_chip;

                    //pictureBox_AdoptionImage.Image = Base64ToImage(selectedAnimal.G_image);
                }
            }
        }

        private void comboBox_AdoptionUName_SelectedIndexChanged(object sender, EventArgs e)  // 0419 ok textboxok feltöltése
        {
            if (comboBox_AdoptionUName.SelectedItem != null)
            {
                // választott
                string selectedUserName = comboBox_AdoptionUName.SelectedItem.ToString();

                // név alapján listában 
                User selectedUser = allUsers.Find(user => user.Name == selectedUserName);

                // Ha meg van, akkor kitöltjük a TextBoxokat
                if (selectedUser != null)
                {
                    textBox_AdoptionAddress.Text = selectedUser.Address;
                    textBox_AdoptionEmail.Text = selectedUser.Email;
                    textBox_AdoptionPhone.Text = selectedUser.Phone.ToString();
                }
            }
        }
       
        private async Task<List<Guest>> allAdoptableAnimal()
        {
            List<Guest> guests = new List<Guest>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{endPoint}/guests?g_adoption=igen";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        guests = JsonConvert.DeserializeObject<List<Guest>>(responseBody);
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült meghívni a vendégeket.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return guests;
        }

        private async Task<List<User>> allUser()
        {
            List<User> users = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{endPoint}/users";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<User>>(responseBody);
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült lekérni a felhasználókat.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return users;
        }

        private async void button_AdoptionInsert_Click(object sender, EventArgs e)  //rögzítés gomb
        {
            // Ell., hogy minden kötelező mező ki van-e töltve 
            //if (string.IsNullOrEmpty(textBox_FoundGender.Text) &&
    

            
                //  új Adoption obj. az űrlap adatatokból
            Adoption newAdoption = new Adoption
            {
                A_date = dateTimePicker_AdoptionDate.Value,
                G_name = comboBox_AdoptionGName.Text,
                U_name = comboBox_AdoptionUName.Text,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,

                
            };

            await InsertAdoption(newAdoption);


            // IMAGE => "default_image.jpg" // Itt beállíthatja az alapértelmezett képet vagy hagyhatja üresen ???? => archiválás Bencébel megbeszélés után

            //insertAdoption metódus meghívása az adatbázisba való beszúráshoz
            //database.insertAdoption(newAdoption);

            // Ha a beszúrás sikeres volt, folytatható a további műveleteket elvégzése

            // Frissítse a ListBox-ot a frissen beszúrt elemmel
            //allAdoptionList(); ??????????????????????????????????????

            // Üzenet a felhasználónak a sikeres beszúrási műveletről
                MessageBox.Show("Az új elem sikeresen hozzá lett adva.", "Sikeres beszúrás", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //********************************
                //*******************************

                Guest selectedAnimal = allAnimals.Find(animal => animal.G_name == comboBox_AdoptionGName.Text);


            if (selectedAnimal != null)
            {
                await DeleteAnimal(selectedAnimal);

                /*selectedAnimal.Delete_at = DateTime.Now;
                //database.adoptionStatusChange(selectedAnimal);

                // Most frissítem az adatbázist is, hogy ez az állat mostantól "nem"-re legyen állítva  Vagy inkáb archiv
                //database.updateAnimalAdoptionStatus(selectedAnimal); <= ez nincs megírva*/
            }

            User selectedUser = allUsers.Find(user => user.Name == comboBox_AdoptionUName.Text);

                FormContract formContract = new FormContract(selectedAnimal, selectedUser);

                formContract.fillData(comboBox_AdoptionGName.Text, textBox_AdoptionSpecies.Text, textBox_AdoptionGender.Text, textBox_AdoptionChip.Text,
                  comboBox_AdoptionUName.Text, textBox_AdoptionAddress.Text, textBox_AdoptionEmail.Text, textBox_AdoptionPhone.Text, dateTimePicker_AdoptionDate.Text);


                formContract.ShowDialog();

                //allAnimals = database.allAdoptableAnimal();

                
                allAnimals = await allAdoptableAnimal();
                allUsers = await allUser();

                uploadingAnimalName();
                uploadingUserName();

                emptyFieldsAdoption();
                placeholderAdoption();
        }
        


        private async Task InsertAdoption(Adoption newAdoption)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{endPoint}/adoptions";
                    var json = JsonConvert.SerializeObject(newAdoption);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, data);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Az örökbefogadás sikeresen rögzítve!");
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült rögzíteni az örökbefogadást!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async Task DeleteAnimal(Guest selectedAnimal)  // 0420 ell, hogy csak akkor, ha inser ok!
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{endPoint}/guests/{selectedAnimal.Id}";
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Az állat sikeresen törölve.");
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült törölni az állatot.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button_AdoptionAgain_Click(object sender, EventArgs e)  // 0419 újra gomb ok m
        {
            emptyFieldsAdoption();
            placeholderAdoption();
        }
    }
}
