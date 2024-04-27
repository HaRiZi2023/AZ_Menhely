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
        { /*
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
            */

           
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
                
        public FormLogin()  // 
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e) // RR
        {
            comboBox_LoginRole.DataSource = Enum.GetValues(typeof(Role));
        }
        
        // ezt 
        private async Task<bool> checkLogin(string name, string password) // u 
        {
            try
            {
                string endpointGet = $"{endPoint}/users?name={name}&password={password}";
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
                    MessageBox.Show("login/checkLogin/else Hiba történt az adatbázis ellenőrzése közben: " + response.ReasonPhrase, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("login/checkLogin/catch Hiba történt az adatbázis ellenőrzése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void button_Login_Click(object sender, EventArgs e) // u 
        {
            string name = textBox_LoginName.Text;
            string password = textBox_LoginPass.Text;

            if (string.IsNullOrEmpty(textBox_LoginName.Text) || string.IsNullOrEmpty(textBox_LoginPass.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét vagy jelszavát!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //textBox_LoginName.Select(); // ??????
                return;
            }

            // Ellenőrizzük a jelszót regex-szel
            var regex = new Regex(@"^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d).{3,10}$");

            if (!regex.IsMatch(password))
            {
                MessageBox.Show("A jelszónak tartalmaznia kell min:3 max:10 karaktert, amiben legalább egy kisbetű, egy nagybetű és egy szám szerepel!", "Hibás jelszó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Select();
                return;
            }

            bool success = await checkLogin(name, password);

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
                //textBox_LoginName.Select();
                return;
            }
        }

        private async Task<bool> checkPermission(string name, string password) // u 
        {
            HttpClient client = new HttpClient();
            string endPoint = ReadSetting("endPointUrl");

            try
            {
                string endPointGet = $"{endPoint}/users?name={name}&password={password}&role=admin";
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
            string name = textBox_LoginName.Text;
            string password = textBox_LoginPass.Text;

            if (validateInputService())
            {
                if (await checkPermission(name, password))
                {
                    //Ha role ==> "admin" 

                    MessageBox.Show("Sikeres szervíz bejelentkezés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // A gombok megjelennek
                    label_LoginId.Visible = true;
                    label_LoginPerm.Visible = true;
                    textBox_LoginId.Visible = true;
                    comboBox_LoginRole.Visible = true;
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
            if (textBox_LoginPass.Text.Length < 3 || textBox_LoginPass.Text.Length > 10)
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
            if (string.IsNullOrEmpty(comboBox_LoginRole.Text))
            {
                MessageBox.Show("Válasszon jogosultságot!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_LoginRole.Focus();
                return false;
            }            
            return true;
        }

        public async Task<bool> isNameInDatabase(string name)
        {
            var response = await client.GetAsync($"{endPoint}/api/checkname?name={name}");
            return response.IsSuccessStatusCode && bool.Parse(await response.Content.ReadAsStringAsync());
        }



        private void emptyFields() // RR - Mezű ürítés
            {
                // Kiürítjük a mezőket
                textBox_LoginName.Text = "";
                textBox_LoginPass.Text = "";
                comboBox_LoginRole.Text = "";
            }

        private async void button_LoginInsert_Click(object sender, EventArgs e)
        {
            string loginInsert = textBox_LoginName.Text;
            if (await isNameInDatabase(loginInsert))
            {
                MessageBox.Show("Van már ilyen nevű dolgozó az adtbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_LoginName.Text = "";
                this.ActiveControl = textBox_LoginName;  // fokusz ide!
            }
            else
            {
                User login = new User();
                if (validateInputService())
                {
                    login.Name = textBox_LoginName.Text;
                    login.Password = textBox_LoginPass.Text;
                    login.Role = comboBox_LoginRole.SelectedValue.ToString();

                    var json = JsonConvert.SerializeObject(login); //-- továbbítandó adat
                    var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                    var response = await client.PostAsync(endPoint, data);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("A dolgozó sikeresen felvitelre került!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("A dolgozó felvétele sikertelen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                emptyFields();
            }
        }

        private void button_LoginUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_LoginName.Text))
            {
                User login = new User();

                login.Id = long.Parse(textBox_LoginId.Text);
                login.Name = textBox_LoginName.Text;
                login.Password = textBox_LoginPass.Text;
                login.Role = comboBox_LoginRole.SelectedValue.ToString();


                var json = JsonConvert.SerializeObject(login); //-- továbbítandó adat
                var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                string endPointUpdate = $"{endPoint}/{login.Id}";
                // ez volt string endPointUpdate = $"{endPoint}/{login.Id}";
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
            if (MessageBox.Show("Valóban törölni szeretné?") == DialogResult.OK)
            {
                User login = new User();

                login.Id = long.Parse(textBox_LoginId.Text);
                string endPointDelete = $"{endPoint}/{login.Id}";
                login.Name = textBox_LoginName.Text;
                login.Password = textBox_LoginPass.Text;
                login.Role = comboBox_LoginRole.SelectedValue.ToString();
                

                string endPointUpdate = $"{endPoint}/{login.Id}";
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
       
