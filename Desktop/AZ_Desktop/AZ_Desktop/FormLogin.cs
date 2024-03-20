using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private string connectionString = "Server=localhost;Database=menhely;Userid=root;Pwd= ;";

        public FormLogin()
        {
            InitializeComponent();
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
                string query = "SELECT w_permission FROM `workers` WHERE `w_name` = @w_name AND `w_password` = `teljes`";
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
            /*if (string.IsNullOrEmpty(comboBox_LoginPermission.Text))
            {
                MessageBox.Show("Kérjük adja meg a jogosultságát!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Select();
                return;
            }*/
            if (checkPermission(w_name, w_password))
            {
                if (w_permission == "teljes") 
                {
                    MessageBox.Show("Sikeres bejelentkezés!");

                     // A TextBox-ok láthatóvá tétele
                    comboBox_LoginPermission.Visible = true;
                    button_LoginInsert.Visible = true;
                    button_LoginUpdate.Visible = true;
                    button_LoginDelete.Visible = true;

                    //openFormMain();
                }
                
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés! Hibás felhasználónév, jelszó vagy jogosultság.");
                textBox_LoginName.Select();
                return;
            }





            /*
            checkPermission(string w_name, string w_password, string w_permission)

            // A TextBox-ok láthatóvá tétele
            comboBox_LoginPermission.Visible = true;
            button_LoginInsert.Visible = true;
            button_LoginUpdate.Visible = true;
            button_LoginDelete.Visible = true;  */
            }
    }
}
