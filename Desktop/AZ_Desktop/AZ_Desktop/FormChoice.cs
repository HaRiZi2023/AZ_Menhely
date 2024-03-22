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
        private Database database;
        private CheckBox[] checkBoxes_Choice;

        public FormChoice() //string options
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

        private void checkBox_CheckedChangedChoice(object sender, EventArgs e) //cb bejlölés változás
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

        private void button_ChoiceChoice_Click(object sender, EventArgs e)  // választás kutya v macska, üres-e
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
                    var dogs = database.allDog();

                    foreach (Guest dog in dogs)
                    {
                        listBox_Choice.Items.Add(dog.G_name); // Feltételezve, hogy a Guest osztályban van egy Name property
                    }
                    break;

                case "checkBox_ChoiceCat":
                    // Az adatbázisból macskák lekérdezése
                    var cats = database.allCat();

                    foreach (Guest cat in cats)
                    {
                        listBox_Choice.Items.Add(cat.G_name); // Feltételezve, hogy a Guest osztályban van egy Name property
                    }
                    break;
            }
        }
                // lent mi az 1?  //
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
       
        private void button_ChoiceInsert_Click(object sender, EventArgs e)  // felvitel gomb
        {
                FormGuest formGuest = new FormGuest();
                formGuest.Show();
           
            
        }

        private void button_ChoiceUpdate_Click(object sender, EventArgs e)
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
                    MessageBox.Show("chosen ok adatokat sikerült lekérdezni", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    FormGuest formGuest = new FormGuest();   // FormGuest példányosítása

                    MessageBox.Show("példányosítás ok", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // adat feltöltése
                    formGuest.uploadData(); // A kiválasztott vendég adatainak betöltése  -  FormGuest adatok beállítása

                    MessageBox.Show("betöltés ok", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    //ÚJ  
                    // FormGuest adatok beállítása
                    //FormGuest.uploadData(selectedGuest); //CS1501 hiba




                    formGuest.Show();   // FormGuest megjelenítése
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

        //********* törlendő **********

        private void button__ChoiceUpdate_Click(object sender, EventArgs e)
        {

        }

        
    }
}
