using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        private Database database;
        private string connectionString = "Server=localhost;Database=menhely;Userid=root;Pwd= ;";

        public FormLogin()
        {
            InitializeComponent();
            database = new Database();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboBox_LoginPermission.Text = "Jogosultság";
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            string w_name = textBox_LoginName.Text;
            string w_password = textBox_LoginPass.Text;

            if (string.IsNullOrEmpty(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Select();
                return;
            }
            if (string.IsNullOrEmpty(textBox_LoginPass.Text))
            {
                MessageBox.Show("Kérjük adja meg a jelszavát!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Select();
                return;
            }
            if (checkLogin(w_name, w_password))
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                openFormMain();
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés! Hibás felhasználónév vagy jelszó.");
                textBox_LoginName.Select();
                return;
            }
        }

        private bool checkLogin(string w_name, string w_password)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
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
            }
        }

        private void openFormMain()
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private bool checkPermission(string w_name, string w_password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                //string query = "SELECT w_permission FROM `workers` WHERE `w_name` = @w_name AND `w_password` = `teljes`";

                string query = "SELECT COUNT(*) FROM `workers` WHERE `w_name` = @w_name AND `w_password` = @w_password AND `w_permission` = 'teljes'";
                /*string query = "SELECT COUNT(*) FROM `workers` WHERE `w_name` = @w_name AND `w_password` = @w_password AND `w_permission` = @w_permission"; //'" + w_permission + "'";*/
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@w_name", w_name);
                    command.Parameters.AddWithValue("@w_password", w_password);
                    /* command.Parameters.AddWithValue("@w_permission", w_permission);*/
                     int count = Convert.ToInt32(command.ExecuteScalar());
                     return count > 0; 
                    /*string permission = command.ExecuteScalar() as string;
                    return permission;*/
                }
            }
        }

        private void button_LoginService_Click(object sender, EventArgs e)
        {
            
            string w_name = textBox_LoginName.Text;
            string w_password = textBox_LoginPass.Text;
            //string w_permission = comboBox_LoginPermission.Text;
           /*
            if (string.IsNullOrEmpty(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Select();
                return;
            }
            if (string.IsNullOrEmpty(textBox_LoginPass.Text))
            {
                MessageBox.Show("Kérjük adja meg a jelszavát!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Select();
                return;
            }
            if (string.IsNullOrEmpty(comboBox_LoginPermission.Text))
            {
                MessageBox.Show("Kérjük adja meg a jogosultságát!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Select();
                return;
            }
          */
            if (checkPermission(w_name, w_password))
            {
                //if (w_permission == "teljes") 
                {
                    MessageBox.Show("Sikeres szervíz bejelentkezés!");

                     // A Button-ok láthatóvá tétele
                    comboBox_LoginPermission.Visible = true;
                    button_LoginInsert.Visible = true;
                    button_LoginUpdate.Visible = true;
                    button_LoginDelete.Visible = true;

                    emptyFields();
                    /*
                    // Kiürítjük a mezőket
                    textBox_LoginName.Text = "";
                    textBox_LoginPass.Text = "";
                    //comboBox_LoginPermission.Text = "";
                    */
                    //openFormMain();
                }

            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés! Hibás felhasználónév, jelszó vagy jogosultság.");
                textBox_LoginName.Select();
                return;
            }
        }

        private bool validateInput() //inserthez + üres konstruktor worksben!
        {
            if (string.IsNullOrEmpty(textBox_LoginName.Text) ||
                string.IsNullOrEmpty(textBox_LoginPass.Text) ||
                string.IsNullOrEmpty(comboBox_LoginPermission.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = textBox_LoginName;

                return false;
            }
            return true;
        }

        private void emptyFields()
        {
            textBox_LoginName.Text = "";
            textBox_LoginPass.Text = "";
            comboBox_LoginPermission.Text = "";
        }

        private void button_LoginInsert_Click(object sender, EventArgs e)
        {
            //textBox_LoginName.Text = "";
            //textBox_LoginPass.Text = "";
            //comboBox_LoginPermission.Text = "";

            string workerInsert = textBox_LoginName.Text;
            if (database.CheckWorkerExists(workerInsert))
            {
                MessageBox.Show("Van már ilyen nevű dolgozó az adtbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_LoginName.Text = "";
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

                };

                // Hívja meg az insertWorker metódust az adatbázisba való beszúráshoz
                database.insertWorker(newWorker);

                // Üzenet a felhasználónak a sikeres beszúrási műveletről
                MessageBox.Show("Az új dolgozó sikeresen felvételre került!", "Sikeres felvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            emptyFields();
        }
             
        private void button_LoginUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérem, írja be a dolgozó nevét!");
                return; // Kilépés a metódusból
            }

            string workerNameUpdate = textBox_LoginName.Text;
            string workerPasswordUpdate = textBox_LoginPass.Text;
            string workerPermissionUpdate = comboBox_LoginPermission.Text;

            if (database.CheckWorkerExists(workerNameUpdate))
            // Ellenőrizzük, hogy van-e ilyen nevű dolgozó
            {  //van találat

                database.updateWorker(workerNameUpdate, workerPasswordUpdate, workerPermissionUpdate);

                MessageBox.Show("Dolgozó adata módosítva lett az adatbázisban.");
            }
            else
            {
                MessageBox.Show("Nincs találat az adatbázisban.");
            }
            emptyFields();
        }
               
        private void button_LoginDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérem, írja be a dolgozó nevét!");
                return; // Kilépés a metódusból
            }

            string workerToDelete = textBox_LoginName.Text;
            /*
            // SQL lekérdezés az adatbázis ellenőrzésére
            string query = "SELECT `w_name` FROM `workes` WHERE `w_name`= @workerName";   //

            var parameters = new { WorkerToDelete = workerToDelete };

            var dataTable = database.ExecuteQuery(query, parameters);
            
            if (dataTable.Rows.Count > 0)
            */

            if (database.CheckWorkerExists(workerToDelete))
            // Ellenőrizd, hogy van-e találat
            {  //van találat
               
                database.deleteWorker(workerToDelete);

                MessageBox.Show("Dolgozó törölve lett az adatbázisból.");
            }
            else
            {
                MessageBox.Show("Nincs találat az adatbázisban.");
            }
            emptyFields();
        }   // ok
    }
}
