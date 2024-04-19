using com.itextpdf.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        int selectedId = 0;

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

        private async Task<Guest> GetSelectedGuest()
        {
            if (listView_Choice.SelectedItems.Count > 0)
            {
                string selectedName = listView_Choice.SelectedItems[0].Text;
                if (await isNameInDatabase(selectedName))
                {
                    // A név szerepel az adatbázisban, itt hozd létre a Guest objektumot
                    Guest guest = new Guest();
                    // Töltsd fel a guest objektumot a megfelelő adatokkal
                    // ...
                    return guest;
                }
                else
                {
                    MessageBox.Show("A kiválasztott név nem szerepel az adatbázisban!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListView-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            /*
            if (listView_Choice.SelectedItems.Count != -1)
            {
                string selectedName = listBox_Choice.SelectedItem.ToString();
                //return Program.database.chosenName(selectedIndex);
            }
            return null; */
        }
        //?????????? kell-e


        public async Task<bool> isNameInDatabase(string g_name)
        {
            var response = await client.GetAsync($"{endPoint}/api/checkname?g_name={g_name}");
            return response.IsSuccessStatusCode && bool.Parse(await response.Content.ReadAsStringAsync());
        }

        // ok 
        private async void button_ChoiceChoice_Click(object sender, EventArgs e)  // választás kutya v macska, üres-e
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
        

        //////////


        private void button_ChoiceInsert_Click(object sender, EventArgs e)  // felvitel gomb átlép m
        {            
            //Új vendég hozzáadása
            FormGuest formGuest = new FormGuest(null, "Insert");
            formGuest.Show();
            
            emptyFieldsChoice();                   
        }

        private void button_ChoiceUpdate_Click(object sender, EventArgs e)  // módosítás gomb átlép m
        {
            /*
            // Kiválasztott módosítása
            Guest selectedGuest = GetSelectedGuest();
            if (selectedGuest != null)
            {
                FormGuest formGuest = new FormGuest(selectedGuest, "Update");
                formGuest.Show();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            emptyFieldsChoice();


            //selectedGuest = GetSelectedGuest();
                   /*    
                if (listBox_Choice.SelectedIndex != -1)
                {
                    // Kiválasztott vendég nevének lekérdezése
                    string selectedGuestName = listBox_Choice.SelectedItem.ToString();

                    // A kiválasztott vendég adatainak lekérdezése a Database osztály segítségével
                    Database database = new Database();
                    Guest selectedGuest = database.chosenName(selectedGuestName); //chosenName(string G_name) ---> kiválasztott név adatainak lekérdezése                     

                    // Ha sikerült lekérdezni az adatokat
                    if (selectedGuest != null)
                    {
                        MessageBox.Show("chosen ok adatokat sikerült lekérdezni " + selectedGuestName, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        FormGuest formGuest = new FormGuest();   // FormGuest példányosítása (listBox_Choice.SelectedItem.ToString());

                        MessageBox.Show("példányosítás ok " + selectedGuestName, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // adat feltöltése
                        formGuest.uploadData(); // A kiválasztott vendég adatainak betöltése  -  FormGuest adatok beállítása

                        MessageBox.Show("betöltés ok " + selectedGuestName, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);


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

            

        */
        }

        private void button_ChoiceDelete_Click(object sender, EventArgs e)// törlés gomb átlép m
        {
          /*
            
            Guest selectedGuest = GetSelectedGuest();
            if (selectedGuest != null)
            {

                FormGuest formGuest = new FormGuest(selectedGuest, "Delete");
                formGuest.Show();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            emptyFieldsChoice();




            /*
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
                FormGuest formGuest = new FormGuest();
                formGuest.Show();
           */  
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
                MessageBox.Show("Nincs kiválasztott elem a listában!");
            }
        }
    }
}
