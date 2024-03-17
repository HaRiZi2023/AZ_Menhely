using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

namespace AZ_Desktop
{
    public partial class FormChoice : Form
    {
        private CheckBox[] checkBoxes_Choice;

        public FormChoice()
        {
            InitializeComponent();
            InitializecheckBoxes_Choice();
        }

        private void FormChoice_Load(object sender, EventArgs e)
        {

        }

        private void InitializecheckBoxes_Choice()
        {
            checkBoxes_Choice = new CheckBox[] { checkBox_ChoiceDog, checkBox_ChoiceCat };

            // Előre beállítjuk a CheckBox-okat
            foreach (var checkBox in checkBoxes_Choice)
            {
                checkBox.CheckedChanged += checkBox_CheckedChangedChoice;
            }
        }

        private void checkBox_CheckedChangedChoice(object sender, EventArgs e)
        {
            var clickedCheckBox = (CheckBox)sender;

            if (clickedCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes_Choice)
                {
                    if (checkBox != clickedCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        private void button_ChoiceChoice_Click(object sender, EventArgs e)
        {
            listBox_Choice.Items.Clear();
            // Ellenőrizzük, hogy van-e kiválasztott CheckBox
            bool anyChecked = false;
            CheckBox selectedCheckBox = null;

            foreach (var checkBox in checkBoxes_Choice)
            {
                if (checkBox.Checked)
                {
                    if (anyChecked)
                    {
                        MessageBox.Show("Kérem válasszon egy CheckBox-ot!");
                        return;
                    }

                    anyChecked = true;
                    selectedCheckBox = checkBox;
                }
            }

            if (!anyChecked)
            {
                MessageBox.Show("Nincs kiválasztott CheckBox!", "Hiányzó bejelölés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Database database = new Database();
            switch (selectedCheckBox.Name)
            {
                case "checkBox_ChoiceDog":
                    // Az adatbázisból kutyák lekérdezése
                    var dogs = database.AllDog();

                    foreach (Guest dog in dogs)
                    {
                        listBox_Choice.Items.Add(dog.G_name); // Feltételezve, hogy a Guest osztályban van egy Name property
                    }
                    break;

                case "checkBox_ChoiceCat":
                    // Az adatbázisból macskák lekérdezése
                    var cats = database.AllCat();

                    foreach (Guest cat in cats)
                    {
                        listBox_Choice.Items.Add(cat.G_name); // Feltételezve, hogy a Guest osztályban van egy Name property
                    }
                    break;
            }
        }
                
        private void listBox_Choice_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e kiválasztott elem a ListBox-ban
            if (listBox_Choice.SelectedIndex != -1)
            {
                // Leolvassuk a kiválasztott elemet
                string selectedGuestName = listBox_Choice.SelectedItem.ToString();

                // Most itt lehet feldolgozni a kiválasztott értéket
                MessageBox.Show("Kiválasztott elem: 111" + selectedGuestName);
            }
        }

        private void button_ChoiceInsert_Click(object sender, EventArgs e)
        {
            if (listBox_Choice.SelectedIndex != -1)
            {
                FormGuest formGuest = new FormGuest();
                // Leolvassuk a kiválasztott elemet
                string selectedGuestName = listBox_Choice.SelectedItem.ToString();

                formGuest.Show();
                //this.Hide(); // Elrejti a bejelentkezési ablakot

                // Most itt lehet feldolgozni a kiválasztott értéket
                MessageBox.Show("Kiválasztott elem: 222 " + selectedGuestName); //guest en jön elő
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button__ChoiceUpdate_Click(object sender, EventArgs e)
        {
            if (listBox_Choice.SelectedIndex != -1)
            {
                // Kiválasztott vendég nevének lekérdezése
                string selectedGuestName = listBox_Choice.SelectedItem.ToString();

                // A kiválasztott vendég adatainak lekérdezése a Database osztály segítségével
                Database database = new Database();
                Guest selectedGuest = database.chosenName(selectedGuestName);

                // Ha sikerült lekérdezni az adatokat
                if (selectedGuest != null)
                {
                    // FormGuest példányosítása
                    FormGuest formGuest = new FormGuest();

                    // FormGuest adatok beállítása
                    //formGuest.guestDataTransfer(selectedGuest);    ////////////////////////////////////////////

                    // A korábbi oldalon lenyomott gomb szövegének átadása
                    formGuest.functionDisplay(button_ChoiceChoice.Text);

                    // FormGuest megjelenítése
                    formGuest.Show();
                }
                else
                {
                    MessageBox.Show("Hiba történt a vendég adatainak lekérése közben.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_ChoiceDelete_Click(object sender, EventArgs e)
        {
            if (listBox_Choice.SelectedIndex != -1)
            {
                // Leolvassuk a kiválasztott elemet
                string selectedGuestName = listBox_Choice.SelectedItem.ToString();

               

                // Most itt lehet feldolgozni a kiválasztott értéket
                MessageBox.Show("Kiválasztott elem: " + selectedGuestName);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
