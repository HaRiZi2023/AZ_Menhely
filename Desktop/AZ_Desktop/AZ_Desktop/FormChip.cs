using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AZ_Desktop
{
    

    public partial class FormChip : Form
    {
        HttpClient client = new HttpClient();        // csak a statikus nem fér hozzá osztályon belül!!!!
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
               
        public FormChip()  // RR - Üres
        {
            InitializeComponent();
            hideAllControls();
        }

        private void FormChip_Load(object sender, EventArgs e)  // RR - Üres  
        {
        }

        private void hideAllControls()
        {
            textBox_ChipName.Visible = false;
            textBox_ChipSpecies.Visible = false;
            richTextBox_ChipOther.Visible = false;
            button_ChipUpdate.Visible = false;
            label_ChipName.Visible = false;
            label_ChipSpecies.Visible = false;
            label_ChipOther.Visible = false;
        }

        // Egyéb alaphelyzetbe állítási műveletek...
        private void button_ChipNew_Click(object sender, EventArgs e)  //RR - Mezőket ürít 
        {
            // Visszaállítjuk a beviteli mezők tartalmát üresre
            textBox_ChipNumber.Text = "";
            hideAllControls();
          
        } 

        public static async Task<bool> CheckChipNumberInDatabase(string chipNumber) // 
        {
            HttpClient client = new HttpClient(); 
            string endPoint = ReadSetting("endpointUrl");

            client.DefaultRequestHeaders.Add("Accept","application/json");

            try
            {
                string apiUrl = $"/guests/chip/{chipNumber}";
                HttpResponseMessage response = await client.GetAsync(endPoint + apiUrl);
                string content = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("C/chekChip/catch   Hiba történt az adatbázis ellenőrzése közben: " + ex.Message);
                return false;
            }
        }

        // chipszám ellenőrzés
        private async void button_ChipControl_Click(object sender, EventArgs e)  // ht
        {
            if (string.IsNullOrWhiteSpace(textBox_ChipNumber.Text)) // ell.kitöltött-e?
            {
                MessageBox.Show("Kérem, írja be a chip számot!");
                this.ActiveControl = textBox_ChipNumber;  // fokusz ide!
                return;
                // Kilépés a metódusból
            }

            string chipNumber = textBox_ChipNumber.Text;

            // Ellenőrizzük, hogy a chipszám 9-es számmal kezdődik-e
            if (!chipNumber.StartsWith("9"))
            {
                MessageBox.Show("A chipszám 9-es számmal kell, hogy kezdődjön!");
                return;
            }

            // Ellenőrizzük, hogy a chipszám 15 számjegyből áll-e
            if (chipNumber.Length != 15)
            {
                MessageBox.Show("A chipszám csak 15 számjegyből állhat!");
                return;
            }

            bool existsInDatabase = await CheckChipNumberInDatabase(chipNumber);

            if (existsInDatabase)
            {
                var guestData = await GetGuestData(chipNumber);

                if (guestData != null)
                {
                    textBox_ChipName.Text = guestData.G_name;
                    textBox_ChipSpecies.Text = guestData.G_species;
                    richTextBox_ChipOther.Text = guestData.G_other;

                    textBox_ChipName.Visible = true;
                    textBox_ChipSpecies.Visible = true;
                    richTextBox_ChipOther.Visible = true;
                    button_ChipUpdate.Visible = true;
                    label_ChipName.Visible = true;
                    label_ChipSpecies.Visible = true;
                    label_ChipOther.Visible = true;

                    MessageBox.Show("A chip szám megtalálható az adatbázisban.", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                hideAllControls();
                MessageBox.Show("***A chip szám nem található az adatbázisban.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Guest> GetGuestData(string chipNumber)
        {
            //HttpClient client = new HttpClient();
            //string endPoint = ReadSetting("endpointUrl");

            try
            {
                string apiUrl = $"/guests/chip/{chipNumber}";
                HttpResponseMessage response = await client.GetAsync(endPoint + apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Guest guestData = JsonConvert.DeserializeObject<Guest>(responseBody);
                    return guestData;
                }
                else
                {
                    MessageBox.Show("C/getguest/ else Hiba történt az adatok lekérése közben.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C/getguest/catch Hiba történt az adatok lekérése közben: " + ex.Message);
                return null;
            }
        }

        private void button_ChipSearch_Click(object sender, EventArgs e)  // RR A felkeresendő petvetdata URL
        {
            // RR A felkeresendő petvetdata URL
            string url = "https://www.petvetdata.hu";

            // Az alapértelmezett böngésző megnyitása az URL-ben
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            Process.Start(psi);
        }  

        private void button_ChipUpdate_Click(object sender, EventArgs e) // 
        {
            Guest guest = new Guest();

            guest.G_other = richTextBox_ChipOther.Text;

            var json = JsonConvert.SerializeObject(guest); //-- továbbítandó adat
            var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
            string endPointUpdate = $"{endPoint}/{guest.Id}";
            var response = client.PutAsync(endPointUpdate, data).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Sikeres módosítás!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sikertelen módosítás!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
    }
}
