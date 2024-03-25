using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Desktop
{
    public partial class FormChip : Form
    {
        private Database database;

        public FormChip()
        {
            InitializeComponent();
            database = new Database();
        }

        private void FormChip_Load(object sender, EventArgs e)
        {

        }  //ok

        private void button_ChipControl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_ChipNumber.Text))
            {
                MessageBox.Show("Kérem, írja be a chip számot!");
                return;
                // Kilépés a metódusból
            }

            string userChipNumber = textBox_ChipNumber.Text;

                           // SQL lekérdezés az adatbázis ellenőrzésére
            string query = "SELECT `g_name`, `g_species`, `g_other` FROM `guests` WHERE `g_chip`= @userChipNumber";   //`g_name`, `g_species`, `g_other`kell csak

            var parameters = new { UserChipNumber = userChipNumber };

            var dataTable = database.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)

                // Ellenőrizd, hogy van-e találat
                //if (dataTable.Rows.Count > 0)
            {
                // Ha van találat, akkor megjelenítjük az adatokat a TextBox-okban
                textBox_ChipName.Text = dataTable.Rows[0]["g_name"].ToString();
                textBox_ChipSpecies.Text = dataTable.Rows[0]["g_species"].ToString();
                richTextBox_ChipOther.Text = dataTable.Rows[0]["g_other"].ToString();
                       
                // A TextBox-ok láthatóvá tétele
                textBox_ChipName.Visible = true;
                textBox_ChipSpecies.Visible = true;
                richTextBox_ChipOther.Visible = true;
                button_ChipUpdate.Visible = true;
            }
            else
            {
                // Ha nincs találat, akkor elrejtjük a TextBox-okat
                textBox_ChipName.Visible = false;
                textBox_ChipSpecies.Visible = false;
                richTextBox_ChipOther.Visible = false;
                button_ChipUpdate.Visible = false;

                MessageBox.Show("Nincs találat az adatbázisban.");
            }
        }  //ok

        private void button_ChipSearch_Click(object sender, EventArgs e)
        {
            // Megadott URL
            string url = "https://www.petvetdata.hu";

            // Az alapértelmezett böngésző megnyitása az URL-ben
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            Process.Start(psi);
        }  //ok

        private void button_ChipUpdate_Click(object sender, EventArgs e)
        {
            string chipNumber = textBox_ChipNumber.Text;
            string otherValue = richTextBox_ChipOther.Text;

            database.updateChipOther(chipNumber, otherValue);

            
        }  //ok

        private void button_ChipNew_Click(object sender, EventArgs e)
        {
            // Visszaállítjuk a beviteli mezők tartalmát
            textBox_ChipNumber.Text = "";

            textBox_ChipName.Visible = false;
            textBox_ChipSpecies.Visible = false;
            richTextBox_ChipOther.Visible = false;
            button_ChipUpdate.Visible = false;

            //richTextBox_Output.Text = "";

            // Egyéb alaphelyzetbe állítási műveletek...
        }  //ok
    }
}
