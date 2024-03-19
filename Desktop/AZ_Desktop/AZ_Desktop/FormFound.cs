using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AZ_Desktop
{
    public partial class FormFound : Form
    {
        private Database database;
        public FormFound()
        {
            InitializeComponent();
            database = new Database();
        }

        private void FormFound_Load(object sender, EventArgs e)
        {
            allFoundList();
        }

        private void allFoundList()
        {
            listBox_Found.Items.Clear();
            Database database = new Database();
              
            var founds = database.allFound();

            foreach (Found found in founds)
            {
                listBox_Found.Items.Add(found.ToString());
            }
        }

        public override string ToString()
        {
            return string.Format("Choice: {F_choice}, Species: {F_species}, Gender: {F_gender}, Injury: {F_injury}, Position: {F_position}, Other: {F_other}");
        }

        private void listBox_Found_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Found.SelectedIndex != -1)
            {            
            Found found = (Found)listBox_Found.SelectedItem;
            textBox_FoundChoice.Text = found.F_choice.ToString();
            textBox_FoundSpecies.Text = found.F_species.ToString();
            comboBox_FoundGender.Text = found.F_gender.ToString();
            textBox_FoundWhere.Text = found.F_position.ToString();
            comboBox_FoundInjury.Text = found.F_injury.ToString();
            //textBox_FoundUser.Text = user.Name.ToString();
            richTextBox_FoundOther.Text = found.Id.ToString();
            }
        }

        private void button_FoundUpdate_Click(object sender, EventArgs e)
        {

        }

       

        private void button_FoundDelete_Click(object sender, EventArgs e)
        {
            if (listBox_Found.SelectedIndex != -1)
            {
                Database database = new Database();
                    // kiolvassuk a kiválasztott elemet
                string selectedFoundId = listBox_Found.SelectedItem.ToString();
                //database.deleteFound(Found found);
                // Azonosító alapján megkeressük a megfelelő Found objektumot az adatbázisból
                Found foundToDelete = Program.database.allFound().FirstOrDefault(found => found.ToString() == selectedFoundId);

                if (foundToDelete != null)
                {
                    // Töröljük a Found objektumot az adatbázisból
                    Program.database.deleteFound(foundToDelete);

                    // Frissítjük a ListBox-ot, hogy a törlés hatására megjelenjenek az új adatok
                    allFoundList();

                    MessageBox.Show("A kiválasztott elem sikeresen törölve lett.", "Sikeres törlés", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   /* // Most itt lehet feldolgozni a kiválasztott értéket
                    MessageBox.Show("Kiválasztott elem: " + selectedFoundId);*/
                }
                else
                {
                    MessageBox.Show("Nem sikerült megtalálni a kiválasztott elemet az adatbázisban.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    /*MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning); */
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            /* Found found = (Found)Program.formFound.listBox_Found.SelectedItem;
            Program.database.deleteFound(found);
            this.Close(); */
        }
    }
}
