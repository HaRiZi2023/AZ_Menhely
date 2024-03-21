using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AZ_Desktop
{
    public partial class FormAdoption : Form
    {
        private Database database;
        private List<Guest> allAnimals;
        private List<User> allUsers;

        public FormAdoption()
        {
            InitializeComponent();

            database = new Database();
            allAnimals = database.allAdoptableAnimal();
            allUsers = database.allUser();
            uploadingAnimalName();
            uploadingUserName();
        }

        private void FormAdoption_Load(object sender, EventArgs e) // Nem jó itt vagy nem csakm ide kéne?!
        {
            placeholderAdoption();
        }

        private void placeholderAdoption()   //mező szöveg
        {
            comboBox_AdoptionGName.Text = "Kérem válasszon!";
            comboBox_AdoptionUName.Text = "Kérem válasszon!";
        }  

        private void uploadingAnimalName() // nevek feltöltése
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

        private void uploadingUserName()  // nevek feltöltése
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

        private void comboBox_AdoptionGName_SelectedIndexChanged(object sender, EventArgs e)  // textboxok feltöltése
        {
            if (comboBox_AdoptionGName.SelectedItem != null)
            {
                // választott
                string selectedAnimalName = comboBox_AdoptionGName.SelectedItem.ToString();

                // név alapján listában 
                Guest selectedAnimal = allAnimals.Find(animal => animal.G_name == selectedAnimalName);

                // Ha meg van, akkor kitöltjük a TextBoxokat
                if (selectedAnimal != null)
                {                    
                    textBox_AdoptionSpecies.Text = selectedAnimal.G_species;
                    textBox_AdoptionGender.Text = selectedAnimal.G_gender;
                    textBox_AdoptionChip.Text = selectedAnimal.G_chip;
                }
            }
        }

        private void comboBox_AdoptionUName_SelectedIndexChanged(object sender, EventArgs e)  // textboxok feltöltése
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

        //**************

        private bool validateInputAdoption() // kitöltés ell.
        {
            if (string.IsNullOrEmpty(comboBox_AdoptionGName.Text) ||
                string.IsNullOrEmpty(comboBox_AdoptionUName.Text)) 
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void emptyFieldsAdoption()  // mezők kiürítése
        {
            comboBox_AdoptionGName.Text = "";
            textBox_AdoptionSpecies.Text = "";
            textBox_AdoptionGender.Text = "";
            textBox_AdoptionChip.Text = "";
            
            comboBox_AdoptionUName.Text = "";
            textBox_AdoptionAddress.Text = "";
            textBox_AdoptionEmail.Text = "";
            textBox_AdoptionPhone.Text = "";

            dateTimePicker_AdoptionDate.Value = DateTime.Now;
        }

        

        private void button_AdoptionInsert_Click(object sender, EventArgs e)
        {
            
            // Ellenőrizze, hogy minden kötelező mező kitöltve van-e
            if (validateInputAdoption())
            {
                //  új Adoption objektumot az űrlap adataiból
                Adoption newAdoption = new Adoption
                {
                    A_date = dateTimePicker_AdoptionDate.Value,
                    G_name = comboBox_AdoptionGName.Text,
                    U_name = comboBox_AdoptionUName.Text,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,

                    // IMAGE => "default_image.jpg" // Itt beállíthatja az alapértelmezett képet vagy hagyhatja üresen ???? => archiválás Bencébel megbeszélés után
                };

                try
                {
                    // Hívja meg az insertAdoption metódust az adatbázisba való beszúráshoz
                    database.insertAdoption(newAdoption);

                    // Ha a beszúrás sikeres volt, folytathatod a további műveleteket

                    // Frissítse a ListBox-ot a frissen beszúrt elemmel
                    //allAdoptionList(); ??????????????????????????????????????

                    // Üzenet a felhasználónak a sikeres beszúrási műveletről
                    MessageBox.Show("Az új elem sikeresen hozzá lett adva.", "Sikeres beszúrás", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //********************************
                    //*******************************

                    Guest selectedAnimal = allAnimals.Find(animal => animal.G_name == comboBox_AdoptionGName.Text);


                    if (selectedAnimal != null && selectedAnimal.G_adoption == "igen")
                    {
                        selectedAnimal.G_adoption = "nem";
                        database.adoptionStatusChange(selectedAnimal);

                        // Most frissítem az adatbázist is, hogy ez az állat mostantól "nem"-re legyen állítva  Vagy inkáb archiv
                        //database.updateAnimalAdoptionStatus(selectedAnimal); <= ez nincs megírva
                    }
                    //********************************
                    //*******************************

                    //database.adoptionStatusChange(selectedAnimal);
                    emptyFieldsAdoption();
                    placeholderAdoption();
                    //allAnimals = database.allAdoptionList();





                }
                catch (Exception ex)
                {
                    // Ha a beszúrás sikertelen volt, kezeljük a hibát vagy adjunk visszajelzést a felhasználónak
                    MessageBox.Show("Hiba történt a beszúrás során: " + ex.Message, "Beszúrás hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
                /*


                // Ki kell venned a kiválasztott állatot
                Guest selectedAnimal = allAnimals.Find(animal => animal.G_name == comboBox_AdoptionGName.Text);

                // Ha a kiválasztott állat nem null és a g_adoption értéke "igen", akkor állítsd át "nem"-re
                if (selectedAnimal != null && selectedAnimal.G_adoption == "igen")
                {
                    selectedAnimal.G_adoption = "nem";

                    // Most frissítem az adatbázist is, hogy ez az állat mostantól "nem"-re legyen állítva  Vagy inkáb archiv
                    //database.updateAnimalAdoptionStatus(selectedAnimal); <= ez nincs megírva
                }*/
            }
        }

        private void button_AdoptionAgain_Click(object sender, EventArgs e)
        {
            emptyFieldsAdoption();
            placeholderAdoption();
        }
        private void button_AdoptionContract_Click(object sender, EventArgs e)
        {
            FormContract formContract = new FormContract();
            formContract.ShowDialog();
            
        }


        //****************** ezt nem biztos hogy megycsinálom

        private void button_AdoptionUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button_AdoptionDelete_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_AdoptionDate_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
