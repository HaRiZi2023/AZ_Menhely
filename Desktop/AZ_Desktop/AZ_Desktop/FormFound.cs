using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            listBox_Found.SelectedIndexChanged += listBox_Found_SelectedIndexChanged; // Ez a sor fontos

        }

        private void FormFound_Load(object sender, EventArgs e)
        {
            allFoundList();
        }

        private void allFoundList()
        {
            listBox_Found.Items.Clear();
            //Database database = new Database();
              
            var founds = database.allFound();

            foreach (Found found in founds)
            {
                listBox_Found.Items.Add(found); //.ToString());
            }
        }
        
        
        private void listBox_Found_SelectedIndexChanged(object sender, EventArgs e) //ez ok
        {
            // MessageBox.Show("ListBox elem kiválasztva!");

            if (listBox_Found.SelectedIndex != -1)
            {
                Found selectedfound = (Found)listBox_Found.SelectedItem;
                textBox_FoundChoice.Text = selectedfound.F_choice.ToString();
                textBox_FoundSpecies.Text = selectedfound.F_species.ToString();
                textBox_FoundGender.Text = selectedfound.F_gender.ToString();
                textBox_FoundInjury.Text = selectedfound.F_injury.ToString();
                textBox_FoundWhere.Text = selectedfound.F_position.ToString();
                richTextBox_FoundOther.Text = selectedfound.F_other.ToString();

                // Ellenőrizzük, hogy a kép nem üres és nem null
                if (!string.IsNullOrEmpty(selectedfound.F_image))
                {
                    // Base64 string visszaalakítása byte tömbbé
                    byte[] imageData = Convert.FromBase64String(selectedfound.F_image);

                    try
                    {
                        // MemoryStream létrehozása a byte tömbből
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            // Kép betöltése a MemoryStream-ből
                            pictureBox_FoundImage.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ha a kép betöltése nem sikerült, jelenítsünk meg egy hibaüzenetet
                        MessageBox.Show($"Nem sikerült betölteni a képet: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Ha a kép üres vagy null értékű, akkor töröljük a pictureBox tartalmát
                    pictureBox_FoundImage.Image = null;
                    // Esetlegesen itt megjeleníthetünk egy üzenetet, hogy nincs kép
                }
            }
        }

        private void emptyFieldsFound()  // mezők kiürítése 
        {
            pictureBox_FoundImage.Image = null;
            listBox_Found.Items.Clear();

            textBox_FoundChoice.Text = "";
            textBox_FoundSpecies.Text = "";
            textBox_FoundGender.Text = "";

            textBox_FoundWhere.Text = "";
            textBox_FoundInjury.Text = "";
            richTextBox_FoundOther.Text = "";

        }
       
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private string ImageToBase64(Image image)// G_imageBase64!
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        private void button_FoundUpdate_Click(object sender, EventArgs e)  // ??? mezőtörlés végére  ????
        {
            if (validateInputFound())  // ki vannak-e töltve
            {
                // Ellenőrizze, hogy van-e kiválasztott elem a ListBox-ban
                if (listBox_Found.SelectedIndex != -1)
                {
                    // Hozzon létre egy Found objektumot az űrlap adataiból
                    Found updatedFound = (Found)listBox_Found.SelectedItem;
                    {
                        //Id = ((Found)listBox_Found.SelectedItem).Id, // Frissítés esetén fontos az azonosító megtartása
                        updatedFound.F_choice = textBox_FoundChoice.Text;
                        updatedFound.F_species = textBox_FoundSpecies.Text;
                        updatedFound.F_gender = textBox_FoundGender.Text;
                        updatedFound.F_injury = textBox_FoundInjury.Text;
                        updatedFound.F_position = textBox_FoundWhere.Text;
                        updatedFound.F_other = richTextBox_FoundOther.Text;

                        //updatedFound.F_image = pictureBox_FoundImage.Image;
                                               
                        updatedFound.Updated_at = DateTime.Now;  //nem működik


                        updatedFound.F_image = ImageToBase64(pictureBox_FoundImage.Image); // A képet nem frissítjük
                        
                        // Hívja meg az updateFound metódust az adatbázisban való frissítéshez
                        database.updateFound(updatedFound);
                        emptyFieldsFound();
                        // Frissítse a ListBox-ot a frissített elemmel
                        allFoundList();





                        // Üzenet a felhasználónak a sikeres frissítésről
                        MessageBox.Show("Sikeres adat frissítés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Ha nincs kiválasztott elem a ListBox-ban, jelenítse meg a figyelmeztető üzenetet
                    MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        //Ez jól működik töröl
        private void button_FoundDelete_Click(object sender, EventArgs e)
        {
            if (listBox_Found.SelectedIndex != -1)
            {
                Found foundToDelete = (Found)listBox_Found.SelectedItem;

                if (foundToDelete != null)
                {
                    database.deleteFound(foundToDelete);
                    emptyFieldsFound();
                    allFoundList(); // Frissítjük a ListBox-ot

                    MessageBox.Show("A kiválasztott elem sikeresen törölve lett.", "Sikeres törlés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nem sikerült megtalálni a kiválasztott elemet az adatbázisban.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //****** Ez majd nem kell inserthez + üres konstruktor *********
        private bool validateInputFound()
        {
            if (string.IsNullOrEmpty(textBox_FoundChoice.Text) ||
                string.IsNullOrEmpty(textBox_FoundSpecies.Text) ||
                string.IsNullOrEmpty(textBox_FoundGender.Text) ||
                string.IsNullOrEmpty(textBox_FoundInjury.Text) ||
                string.IsNullOrEmpty(textBox_FoundWhere.Text)) 
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void button_FoundInsert_Click(object sender, EventArgs e) 
        {
            // Ellenőrizze, hogy minden kötelező mező kitöltve van-e
            if (validateInputFound())
            {
                // Hozzon létre egy új Found objektumot az űrlap adataiból
                Found newFound = new Found
                {
                    F_choice = textBox_FoundChoice.Text,
                    F_species = textBox_FoundSpecies.Text,
                    F_gender = textBox_FoundGender.Text,
                    F_injury = textBox_FoundInjury.Text,
                    F_position = textBox_FoundWhere.Text,
                    F_other = richTextBox_FoundOther.Text,
                    //F_image = "default_image.jpg" // Itt beállíthatja az alapértelmezett képet vagy hagyhatja üresen
                };

                // Hívja meg az insertFound metódust az adatbázisba való beszúráshoz
                database.insertFound(newFound);

                // Frissítse a ListBox-ot a frissen beszúrt elemmel
                allFoundList();

                // Üzenet a felhasználónak a sikeres beszúrási műveletről
                MessageBox.Show("Az új elem sikeresen hozzá lett adva.", "Sikeres beszúrás", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }    
    }
}
