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

        private void FormAdoption_Load(object sender, EventArgs e)
        {

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

        private void comboBox_AdoptionGName_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox_AdoptionUName_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dateTimePicker_AdoptionDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
