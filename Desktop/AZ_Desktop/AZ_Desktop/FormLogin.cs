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
using System.Text;
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
                
        public FormLogin()  // 
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e) // RR
        {
            comboBox_LoginPermission.Text = "Jogosultság";
            comboBox_LoginPermission.DataSource = Enum.GetValues(typeof(W_permission));
        }
        /*
        // nem kell
        private async void uploadingWorkerName() // nevek feltöltése cb
        {/*
            textBox_LoginName.Clear();
            try
            {
                HttpResponseMessage response = await client.GetAsync(endPoint);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var workers = Worker.FromJson(jsonString);


                    // Beállítjuk a DisplayMember tulajdonságot, hogy a ComboBox megfelelően jelenítse meg a neveket
                    //textBox_LoginName = ""; // A "Name" a Worker osztály nevére utal, kicseréld az aktuális mezőre

                    foreach (Worker item in workers)
                    {
                        //textBox_LoginName.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        /*
        private async void allWorker()  //ua mint fent
        {
            textBox_LoginName.Clear();
            try
            {
                HttpResponseMessage response = await client.GetAsync(endPoint);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var workers = Worker.FromJson(jsonString);
                    foreach (Worker item in workers)
                    {
                        //textBox_LoginName.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    */

        // belépés
        private async void button_Login_Click(object sender, EventArgs e) // u 
        {
            string w_name = textBox_LoginName.Text;
            string w_password = textBox_LoginPass.Text;

            if (string.IsNullOrEmpty(textBox_LoginName.Text) || string.IsNullOrEmpty(textBox_LoginPass.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Select();
                return;
            }

            bool success = await checkLogin(w_name, w_password);


            if (success)
            {
                MessageBox.Show("Sikeres bejelentkezés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                openFormMain();
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés! Hibás felhasználónév vagy jelszó.");
                textBox_LoginName.Select();
                return;
            }
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
                MessageBox.Show("/X/Hiba történt az adatbázis ellenőrzése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           





            /*
            if (validateInputLogin()) // ell.kitöltött-e?
            {
                try
                {
                    bool existsInDatabase = await CheckLoginInDatabase(w_name, w_password);

                    if (existsInDatabase)
                    {
                        MessageBox.Show("Sikeres belépés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("A megadott név vagy jelszó hibás!", "Sikertelen belépés", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázis ellenőrzése közben: " + ex.Message, "Adatbázis hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Hiba a validálás során!", "Sikertelen belépés", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Ha a belépési adatok nem voltak kitöltve
            }

           
            string workerName = textBox_LoginName.Text;
            string workerPassword = textBox_LoginPass.Text;

            bool existsInDatabase = await CheckLoginInDatabase(w_name, w_password);

            if (existsInDatabase)
            {
                

                MessageBox.Show("Ez a név nem megtalálható az adatbázisban.", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ez a név megtalálható az adatbázisban.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM `workers` WHERE `w_name` = @w_name AND `w_password`= @w_password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@w_name", w_name);
                    command.Parameters.AddWithValue("@w_password", w_password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }*/
        }
        // ?????? nem
        private async Task<bool> CheckLoginInDatabase(string workerName, string workerPassword)
        {
            HttpClient client = new HttpClient();
            string endPoint = ReadSetting("endPointUrl");

            try
            {
                string endPointGet = $"{endPoint}/workers?name={workerName}&password={workerPassword}";  // Az endpoint URL-jét az App.config.cs-ből olvassuk ki
                HttpResponseMessage response = await client.GetAsync(endPointGet);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);

                    return (bool)jsonResponse["exists"]; // A válasz JSON tartalmazza, hogy a dolgozó szerepel-e az adatbázisban


                }
                else
                {
                    MessageBox.Show("Hiba történt az adatbázis ellenőrzése közben: ", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatbázis ellenőrzése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void openFormMain() // RR - Átlépés mainre
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        /********************/
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

                    MessageBox.Show("Sikeres szervíz bejelentkezés!");

                    // A gombok megjelennek
                    comboBox_LoginPermission.Visible = true;
                    button_LoginInsert.Visible = true;
                    button_LoginUpdate.Visible = true;
                    button_LoginDelete.Visible = true;

                    emptyFields();
                }
                else
                {
                    MessageBox.Show("**Sikertelen bejelentkezés! Hibás felhasználónév, jelszó vagy jogosultság.");
                    textBox_LoginName.Select();
                    return;
                }
            }
        }

        // kitöltöttség ellenőrzés
        /*
        private bool validateInputLogin() // RR inserthez + üres konstruktor worksben!
        {
            if (string.IsNullOrEmpty(textBox_LoginName.Text) ||
                string.IsNullOrEmpty(textBox_LoginPass.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = textBox_LoginName;  // fokusz ide!

                return false;
            }
            return true;
        }
        */
        private bool validateInputService() // RR inserthez + üres konstruktor worksben!
        {
            if (string.IsNullOrEmpty(textBox_LoginName.Text) ||
                string.IsNullOrEmpty(textBox_LoginPass.Text) ||
                string.IsNullOrEmpty(comboBox_LoginPermission.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = textBox_LoginName;  // fokusz ide!

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

        /*** gombok ***/

        private void button_LoginInsert_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            if (string.IsNullOrEmpty(textBox_LoginName.Text))
            {
                MessageBox.Show("Név megadása kötelező");
                textBox_LoginName.Focus();
                return;
            }
            worker.W_name = textBox_LoginName.Text;
            worker.W_password = textBox_LoginPass.Text;
            worker.W_permission = comboBox_LoginPermission.SelectedValue.ToString();
           
            var json = JsonConvert.SerializeObject(worker); //-- továbbítandó adat
            var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
            var response = client.PostAsync(endPoint, data).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Sikeres felvitel!");
                //listafrissitese();
            }
            else
            {
                MessageBox.Show("Sikertelen felvitel!");
            }


            /*
            string workerInsert = textBox_LoginName.Text;
            if (database.CheckWorkerExists(workerInsert))
            {
                MessageBox.Show("Van már ilyen nevű dolgozó az adtbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_LoginName.Text = "";
                this.ActiveControl = textBox_LoginName;  // fokusz ide!
            }

            // Ellenőrizze, hogy minden kötelező mező kitöltve van-e
            if (validateInput())
            {
                // Hozzon létre egy új Worker objektumot az űrlap adataiból
                Worker newWorker = new Worker
                {
                    W_name = textBox_LoginName.Text,
                    W_password = textBox_LoginPass.Text,
                    W_permission = comboBox_LoginPermission.Text,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                };

                // Hívja meg az insertWorker metódust az adatbázisba való beszúráshoz
                database.insertWorker(newWorker);

                // Üzenet a felhasználónak a sikeres beszúrási műveletről
                MessageBox.Show("Az új dolgozó sikeresen felvételre került!", "Sikeres felvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            emptyFields();
        }

        private void button_LoginUpdate_Click(object sender, EventArgs e)
        {





            emptyFields();
            /*if (string.IsNullOrWhiteSpace(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérem, írja be a dolgozó nevét!");
                return; // Kilépés a metódusból
            }*/

            /*
            string workerUpdate = textBox_LoginName.Text;
            if (database.CheckWorkerExists(workerUpdate)) //van dolgozó
            {
                if (validateInput())
                {
                    string workerNameUpdate = textBox_LoginName.Text;
                    string workerPasswordUpdate = textBox_LoginPass.Text;
                    string workerPermissionUpdate = comboBox_LoginPermission.Text;

                    if (database.CheckWorkerExists(workerNameUpdate))
                    // Ellenőrizzük, hogy van-e ilyen nevű dolgozó
                    {  //van találat

                        database.updateWorker(workerNameUpdate, workerPasswordUpdate, workerPermissionUpdate);

                        // Üzenet a felhasználónak a sikeres beszúrási műveletről
                        MessageBox.Show("A dolgozó adatai sikeresen módosítva!", "Sikeres módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    

                    // Hívja meg az updateWorker metódust az adatbázisba való beszúráshoz
                    database.updateWorker(newWorker);

                // Üzenet a felhasználónak a sikeres beszúrási műveletről
                MessageBox.Show("A dolgozó adatai sikeresen módosítva!", "Sikeres módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                emptyFields();
            }
            else
            {
                MessageBox.Show("Nincs ilyen nevű dolgozó az adtbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Text = "";
                this.ActiveControl = textBox_LoginName;  // fokusz ide!
            }*/
        }

        private void button_LoginDelete_Click(object sender, EventArgs e)  // ide még checkWorkerEx !!!!!!!!!! 
        {
            if (string.IsNullOrWhiteSpace(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérem, írja be a dolgozó nevét!");
                return; // Kilépés a metódusból
            }

            if (MessageBox.Show("valóban törölni akarja?") == DialogResult.OK)
            {
                Worker worker = new Worker();
                
                worker.W_name = textBox_LoginName.Text;
                worker.W_password = textBox_LoginName.Text;
                worker.W_permission = comboBox_LoginPermission.SelectedValue.ToString();


                string endPointDelete = $"{endPoint}/{worker.Id}";
                var response = client.DeleteAsync(endPointDelete).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres törlés.", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sikertelen törlés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            emptyFields();


            //string workerDelete = textBox_LoginName.Text;
            /*
            // SQL lekérdezés az adatbázis ellenőrzésére
            string query = "SELECT `w_name` FROM `workes` WHERE `w_name`= @workerName";   //

            var parameters = new { WorkerToDelete = workerToDelete };

            var dataTable = database.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            */
            /*
            if (database.CheckWorkerExists(workerDelete))
            // Ellenőrizd, hogy van-e találat
            {  //van találat

                database.deleteWorker(workerDelete);

                MessageBox.Show("Dolgozó törölve lett az adatbázisból.");
            }
            else
            {
                MessageBox.Show("Nincs találat az adatbázisban.");
            }
            emptyFields(); */
        }  // ok
    }
}
       
