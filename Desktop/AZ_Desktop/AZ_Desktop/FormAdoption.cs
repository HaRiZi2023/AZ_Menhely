using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AZ_Desktop
{
    public partial class FormAdoption : Form
    {
        private Database database;
        public FormAdoption()
        {
            InitializeComponent();
            database = new Database();
            uploadingAnimalName();
            uploadingUserName();
        }

        private void FormAdoption_Load(object sender, EventArgs e)
        {

        }

        private void uploadingAnimalName()
        {
            comboBox_AdoptionGName.Items.Clear();
            //Database database = new Database();
            /*
            var founds = database.allFound();

            foreach (Found found in founds)
            {
                listBox_Found.Items.Add(found); //.ToString());
            }
            




            // Adatbázis kapcsolat létrehozása
            using (SqlConnection connection = new SqlConnection("your_connection_string_here"))
            {
                // SQL parancs létrehozása
                string query = "SELECT column_name FROM your_table_name";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Adatbázis kapcsolat megnyitása
                    connection.Open();

                    // Adatok olvasása
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> guestList = new List<string>();

                    // Adatok hozzáadása a listához
                    while (reader.Read())
                    {
                        guestList.Add(reader["column_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázisból való adatok lekérdezésekor: " + ex.Message);
                }
            }*/
        } 

        private void uploadingUserName()
        {
            comboBox_AdoptionUName.Items.Clear();
            //Database database = new Database();
            /*
            var founds = database.allFound();

            foreach (Found found in founds)
            {
                listBox_Found.Items.Add(found); //.ToString());
            }
            */
            



            // Adatbázis kapcsolat létrehozása
            using (SqlConnection connection = new SqlConnection("Server=localhost;UserID=root;Password= ,Database=menhely;CharacterSet=utf8;"))
            {
                // SQL parancs létrehozása
                string query = "SELECT 'name' FROM `users`";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Adatbázis kapcsolat megnyitása
                    connection.Open();

                    // Adatok olvasása
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> userList = new List<string>();

                    // Adatok hozzáadása a listához
                    while (reader.Read())
                    {
                        userList.Add(reader["name"].ToString());
                    }

                    // ComboBox frissítése az elemekkel
                    comboBox_AdoptionUName.DataSource = userList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázisból való adatok lekérdezésekor: " + ex.Message);
                }
            }
        }




    }
}
