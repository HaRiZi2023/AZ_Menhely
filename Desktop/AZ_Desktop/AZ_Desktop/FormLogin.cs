using iTextSharp.xmp.impl;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AZ_Desktop
{
    public partial class FormLogin : Form
    {
        HttpClient client = new HttpClient();
        string endPoint = ReadSetting("endpointUrl");
        // ezt megnézni!!!!
        private static string ReadSetting(string keyName)
        {
            try
            {
                var value = ConfigurationManager.AppSettings;
                if (value[keyName] == null)
                {
                    throw new ConfigurationErrorsException($"A {keyName} kulcs nem található a konfigurációs fájlban.");
                }
                return value[keyName];
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


            /*
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
            */
        }
                
        public FormLogin()  // 
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e) // RR
        {
            comboBox_LoginPermission.DataSource = Enum.GetValues(typeof(W_permission));
        }
        
        // ezt 
        private async Task<bool> checkLogin(string w_name, string w_password) // u 
        {
            try
            {
                string endpointGet = $"{endPoint}/workers?name={w_name}&password={w_password}";
                HttpResponseMessage response = await client.GetAsync(endpointGet);

                //using (HttpClient client = new HttpClient())
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JArray jsonResponse = JArray.Parse(responseBody);
                    return jsonResponse.Count > 0;
                }
                else
                {
                    MessageBox.Show("/X/Hiba történt az adatbázis ellenőrzése közben: " + response.ReasonPhrase, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("/X*/Hiba történt az adatbázis ellenőrzése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void button_Login_Click(object sender, EventArgs e) // u 
        {
            string w_name = textBox_LoginName.Text;
            string w_password = textBox_LoginPass.Text;

            if (string.IsNullOrEmpty(textBox_LoginName.Text) || string.IsNullOrEmpty(textBox_LoginPass.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét vagy jelszavát!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //textBox_LoginName.Select(); // ??????
                return;
            }

            // Ellenőrizzük a jelszót regex-szel
            var regex = new Regex(@"^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d).{3,10}$");

            if (!regex.IsMatch(w_password))
            {
                MessageBox.Show("A jelszónak tartalmaznia kell min:3 max:10 karaktert, amiben legalább egy kisbetű, egy nagybetű és egy szám szerepel!", "Hibás jelszó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Select();
                return;
            }

            bool success = await checkLogin(w_name, w_password);

            if (success)
            {
                MessageBox.Show("Sikeres bejelentkezés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormMain formMain = new FormMain();
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés! Hibás felhasználónév vagy jelszó.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_LoginName.Select();
                return;
            }
        }

        private async Task<bool> checkPermission(string w_name, string w_password) // u 
        {
            HttpClient client = new HttpClient();
            string endPoint = ReadSetting("endPointUrl");

            try
            {
                string endPointGet = $"{endPoint}/workers?name={w_name}&password={w_password}&permission=teljes";
                HttpResponseMessage response = await client.GetAsync(endPointGet);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JArray jsonResponse = JArray.Parse(responseBody);

                    return jsonResponse.Count > 0;
                }
                else
                {
                    MessageBox.Show("***Hiba történt az adatbázis ellenőrzése közben: ", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("****Hiba történt az adatbázis ellenőrzése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void button_LoginService_Click(object sender, EventArgs e) // u Szervíz belépés ell.
        {
            string w_name = textBox_LoginName.Text;
            string w_password = textBox_LoginPass.Text;

            if (validateInputService())
            {
                if (await checkPermission(w_name, w_password))
                {
                    //Ha w_permission ==> "teljes" 

                    MessageBox.Show("Sikeres szervíz bejelentkezés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // A gombok megjelennek
                    label_LoginPerm.Visible = true;
                    comboBox_LoginPermission.Visible = true;
                    button_LoginInsert.Visible = true;
                    button_LoginUpdate.Visible = true;
                    button_LoginDelete.Visible = true;

                    emptyFields();
                }
                else
                {
                    MessageBox.Show("**Sikertelen szervíz bejelentkezés! Hibás felhasználónév, jelszó vagy jogosultság.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_LoginName.Select();
                    return;
                }
            }
        }
               
        private bool validateInputService() // RR inserthez + üres konstruktor worksben!
        { //-- adatellenőrzés
            if (string.IsNullOrEmpty(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Focus();
                return false;
            }
            if (textBox_LoginPass.Text.Length <= 3 && textBox_LoginPass.Text.Length >= 10)
            {
                // Ellenőrizzük a jelszót regex-szel
                var password = textBox_LoginPass.Text;
                var regex = new Regex(@"^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d).{3,10}$");
                if (!regex.IsMatch(password))
                {
                    MessageBox.Show("Jelszó megadása kötelező! Jelszónak tartalmaznia kell min:3 max:10 karaktert, amiben legalább egy kisbetű, egy nagybetű és egy szám szerepel!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_LoginPass.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(comboBox_LoginPermission.Text))
            {
                MessageBox.Show("Válasszon jogosultságot!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_LoginPermission.Focus();
                return false;
            }            
            return true;
        }

        private void emptyFields() // RR - Mezű ürítés
        {
            // Kiürítjük a mezőket
            textBox_LoginName.Text = "";
            textBox_LoginPass.Text = "";
            comboBox_LoginPermission.Text = "";
        }

        private void button_LoginInsert_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            if (validateInputService())
            {
                worker.W_name = textBox_LoginName.Text;

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textBox_LoginPass.Text));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    worker.W_password = builder.ToString();
                }

                worker.W_permission = comboBox_LoginPermission.SelectedValue.ToString();

                var json = JsonConvert.SerializeObject(worker); //-- továbbítandó adat
                var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                var response = client.PostAsync(endPoint, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("A dolgozó sikeresen felvitelre került!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
            else
            {
                MessageBox.Show("felvitel/else A dolgozó felvétele sikertelen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            emptyFields();
        }

        private void button_LoginUpdate_Click(object sender, EventArgs e)
        {
            if (validateInputService())
            {
                Worker worker = new Worker();

                //workerUdate.Id = long.Parse(textBox_id.Text);
                worker.W_name = textBox_LoginName.Text;
                worker.W_password = textBox_LoginPass.Text;
                worker.W_permission = comboBox_LoginPermission.SelectedValue.ToString();


                var json = JsonConvert.SerializeObject(worker); //-- továbbítandó adat
                var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                string endPointUpdate = $"{endPoint}/{worker.Id}";
                var response = client.PutAsync(endPointUpdate, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("A dolgozó sikeresen módosításra került!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("A dolgozó módosítása sikertelen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            emptyFields();
        }

        private void button_LoginDelete_Click(object sender, EventArgs e)  // ide még checkWorkerEx !!!!!!!!!! 
        {
            if (validateInputService())
            {
                Worker worker = new Worker();

                //worker.Id = long.Parse(textBox_id.Text);
                string endPointDelete = $"{endPoint}/{worker.Id}";
                worker.W_name = textBox_LoginName.Text;
                worker.W_password = textBox_LoginPass.Text;
                worker.W_permission = comboBox_LoginPermission.SelectedValue.ToString();
                

                string endPointUpdate = $"{endPoint}/{worker.Id}";
                var response = client.DeleteAsync(endPointUpdate).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("A dolgozó sikeresen törlve lett!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("A dolgozó törlése sikertelen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            emptyFields();
        }
    }
}
       
