using com.itextpdf.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace AZ_Desktop
{
   
    public partial class FormChoice : Form
    {
        HttpClient client = new HttpClient();
        string endPoint = ReadSetting("endpointUrl");

        private CheckBox[] checkBoxes_Choice;
        int selectedId = 0;  //????

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

        public FormChoice() //string options
        {
            InitializeComponent();
            InitializecheckBoxes_Choice();  
        }

        private void FormChoice_Load(object sender, EventArgs e)
        {
            listView_Choice.FullRowSelect = true; //  egész sor jelölve legyen
        }

        private void InitializecheckBoxes_Choice()
        {
            checkBoxes_Choice = new CheckBox[] { checkBox_ChoiceDog, checkBox_ChoiceCat };

            // CheckBox-ok eseménykezelője (hozzáadása)
            foreach (var checkBox in checkBoxes_Choice)
            {
                checkBox.CheckedChanged += checkBox_CheckedChangedChoice;
            }
        }

        private void checkBox_CheckedChangedChoice(object sender, EventArgs e) //cb bejlölés változás ok m
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


        //szerintem guestbe
        public async Task<bool> isNameInDatabase(string g_name)
        {
            var response = await client.GetAsync($"{endPoint}/api/checkname?g_name={g_name}");
            return response.IsSuccessStatusCode && bool.Parse(await response.Content.ReadAsStringAsync());
        }

        // ok 
        private async void button_ChoiceChoice_Click(object sender, EventArgs e)  // választás kutya v macska, üres-e
        {
            listBox_Choice.Items.Clear();  //View
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
                return;
            }

            // Itt kezdődik az új kód
            string url = endPoint; // Az endPoint-ból származtatjuk az URL-t

            if (selectedCheckBox == checkBox_ChoiceDog)
            {
                url += "/guests/all/dogs";
            }
            else if (selectedCheckBox == checkBox_ChoiceCat)
            {
                url += "/guests/all/cats";
            }
           
            try
            {
                 HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Guest> items = JsonConvert.DeserializeObject<List<Guest>>(data);

                    listView_Choice.Items .Clear();

                    foreach (var item in items)
                    {
                        listBox_Choice.Items.Add(item);

                        ListViewItem listViewItem = new ListViewItem(item.Id.ToString()); 
                        listViewItem.SubItems.Add(item.G_name);

                        listView_Choice.Items.Add(listViewItem);
                    }
                }
                else
                {
                    MessageBox.Show("Hiba történt az adatok lekérése közben!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a kérés közben: {ex.Message}", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            /*
            Database database = new Database();
            switch (selectedCheckBox.Name)
            {
                case "checkBox_ChoiceDog":
                    // Az adatbázisból kutyák lekérdezése
                    var dogs = database.allDog();

                    foreach (Guest dog in dogs)
                    {   // listbox feltöltése
                        listBox_Choice.Items.Add(dog.G_name); // Feltételezve, hogy a Guest osztályban van egy Name property
                    }
                    break;

                case "checkBox_ChoiceCat":
                    // Az adatbázisból macskák lekérdezése
                    var cats = database.allCat();

                    foreach (Guest cat in cats)
                    {       // listbox feltöltése
                        listBox_Choice.Items.Add(cat.G_name); // Feltételezve, hogy a Guest osztályban van egy Name property
                    }
                    break;
            }*/
        }
                // nincs ?????
        private void listBox_Choice_SelectedIndexChanged_1(object sender, EventArgs e) // üres
        { /*
            // Ellenőrizzük, hogy van-e kiválasztott elem a ListBox-ban
            if (listBox_Choice.SelectedIndex != -1)
            {
                // Leolvassuk a kiválasztott elemet
                string selectedGuestName = listBox_Choice.SelectedItem.ToString();

                // Létrehozunk egy új Guest objektumot a kiválasztott névvel
                Guest selectedGuest = new Guest();
                selectedGuest.G_name = selectedGuestName;
                /*
                FormGuest formGuest = new FormGuest(selectedGuest);
                formGuest.Show();

                // Most itt lehet
                MessageBox.Show("Kiválasztott elem: 111 - " + selectedGuestName);
            }
            */
        }

        
        private void emptyFieldsChoice()  // ok m
        {
            // Kiürítjük a mezőket
          
            checkBox_ChoiceCat.Checked = false;
            checkBox_ChoiceDog.Checked = false;

            listView_Choice.Items.Clear();
            //CheckBox selectedCheckBox = null;
        
        }
        
        private void button_ChoiceInsert_Click(object sender, EventArgs e)  // felvitel gomb átlép m
        {            
            //Új vendég hozzáadása
            FormGuest formGuest = new FormGuest(0, "Insert");
            formGuest.Show();
            
            emptyFieldsChoice();                   
        }

        private void button_ChoiceUpdate_Click(object sender, EventArgs e)  // módosítás gomb átlép m
        {
            if (listView_Choice.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = listView_Choice.SelectedItems[0];
                int selectedId = int.Parse(listViewItem.SubItems[0].Text);

                FormGuest formGuest = new FormGuest(selectedId, "Update");
                formGuest.Show();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában!");
            }
            emptyFieldsChoice();
        }

        private void button_ChoiceDelete_Click(object sender, EventArgs e)// törlés gomb átlép selectedet átviszi
        {
            if (listView_Choice.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = listView_Choice.SelectedItems[0];
                int selectedId = int.Parse(listViewItem.SubItems[0].Text);

                FormGuest formGuest = new FormGuest(selectedId, "Delete");
                formGuest.Show();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában!");
            }
            emptyFieldsChoice();
        }

        private void listView_Choice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView_Choice.SelectedIndices.Count > 0)
            {
                ListViewItem listViewItem = listView_Choice.SelectedItems[0];
                int selectedId = int.Parse(listViewItem.SubItems[0].Text);
                Debug.WriteLine("id: " + selectedId); // nem kell majd!
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
