﻿using Google.Protobuf.WellKnownTypes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace AZ_Desktop
{
    public partial class FormGuest : Form
    {
        private Guest selectedGuest;
       
        //private Database database;


        public FormGuest()
        {
            InitializeComponent();

            //this.selectedGuest = selectedGuest;

            //uploadData();
            


            //database = new Database();
            //listBox_Choice.SelectedIndexChanged += listBox_Choice_SelectedIndexChanged; // Ez a sor fontos

        }

        public FormGuest(Guest selectedGuest)
        {
            InitializeComponent();
            this.selectedGuest = selectedGuest;
            uploadData();
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {
            this.Text = "Felvitel";
            button_GuestInsert.Text = "Felvitel";
            button_GuestInsert.BackColor = Color.LightGreen;
            button_GuestInsert.Click += new EventHandler(insertGuest);
            /*
            this.Text = "Módosítás";
            button_GuestSending.Text = "Módosítás";
            button_GuestSending.BackColor = Color.LightBlue;
            button_GuestSending.Click += new EventHandler(insertGuest);

            this.Text = "Törlés";
            button_GuestSending.Text = "Törlés";
            button_GuestSending.BackColor = Color.LightSalmon;
            button_GuestSending.Click += new EventHandler(insertGuest);
            */



            /*
            switch (options)
            {
                case "Insert":
                    this.Text = "Felvitel";
                    button_GuestSending.Text = "Felvitel";
                    button_GuestSending.BackColor = Color.LightGreen;
                    button_GuestSending.Click += new EventHandler(insertGuest);
                    break;
                case "Update":
                    this.Text = "Módosítás";
                    button_GuestSending.Text = "Módosítás";
                    button_GuestSending.BackColor = Color.LightBlue;
                    button_GuestSending.Click += new EventHandler(updateGuest);
                    uploadData();
                    break;
                case "Delete":
                    this.Text = "Törlés";
                    button_GuestSending.Text = "Törlés";
                    button_GuestSending.BackColor = Color.LightSalmon;
                    button_GuestSending.Click += new EventHandler(deleteGuest);
                    uploadData();
                    break;
            


                    //uploadData(); // adat feltöltése
            }*/
        }
        
        public void uploadData()  // adat feltöltése () üres upload
        {

            if (selectedGuest != null)
            //if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                //Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;

                textBox_GuestName.Text = selectedGuest.G_name.ToString();
                textBox_GuestChip.Text = selectedGuest.G_chip.ToString();
                textBox_GuestWhere.Text = selectedGuest.G_in_place.ToString();
                comboBox_GuestSpecies.Text = selectedGuest.G_species.ToString();
                comboBox_GuestGender.Text = selectedGuest.G_gender.ToString();
                comboBox_GuestAdoption.Text = selectedGuest.G_adoption.ToString();
                dateTimePicker_GuestIn.Value = selectedGuest.G_in_date;
                dateTimePicker_GuestOut.Value = selectedGuest.G_out_date;
                richTextBox_GuestOther.Text = selectedGuest.G_other.ToString();

                try
                {
                    using (MemoryStream ms = new MemoryStream(selectedGuest.G_image))
                    {
                        pictureBox_GuestImage.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A kép megjelenítése sikertelen: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                /*
                if (selectedGuest.G_image != null && selectedGuest.G_image.Length > 0)
                {
                    try
                    {
                        // Kép betöltése byte tömbből
                        using (MemoryStream ms = new MemoryStream(selectedGuest.G_image))
                        {
                            pictureBox_GuestImage.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba a kép megjelenítésekor: " + ex.Message);
                    }
                }*/


                /*
                // Kép megjelenítése a PictureBox kontrollon
                if (!string.IsNullOrEmpty(selectedGuest.G_image))
                {
                    try
                    {
                        // Kép betöltése byte tömbből
                        byte[] imageData = Convert.FromBase64String(selectedGuest.G_image);
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox_GuestImage.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba a kép megjelenítésekor: " + ex.Message);
                    }
                }
                */
                /*
                if (selectedGuest.G_image != null)
                {
                    using (MemoryStream ms = new MemoryStream(selectedGuest.G_image))
                    {
                        pictureBox_GuestImage.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox_GuestImage.Image = null;
                    //pictureBox_GuestImage.Image = selectedGuest.G_image.;
                }*/
            }
        }

        private void emptyFieldsGuest()  // mezők kiürítése
        {
            textBox_GuestName.Text = "";
            textBox_GuestChip.Text = "";
            textBox_GuestWhere.Text = "";
            comboBox_GuestSpecies.Text = "";
            comboBox_GuestGender.Text = "";
            comboBox_GuestAdoption.Text = "";
            dateTimePicker_GuestIn.Value = DateTime.Now;
            dateTimePicker_GuestOut.Value = DateTime.Now;
            richTextBox_GuestOther.Text = "";
        }


        //*************************
        // nem kellenek
        private void insertGuest(object sender, EventArgs e)
        {
             /*
            Guest guest = new Guest();

            guest.G_name = textBox_GuestName.Text;
            guest.G_chip = textBox_GuestChip.Text;
            guest.G_in_place = textBox_GuestWhere.Text;
            guest.G_species = comboBox_GuestSpecies.Text;
            guest.G_gender = comboBox_GuestGender.Text;
            guest.G_adoption = comboBox_GuestAdoption.Text;
            //guest.G_in_date = (DateTime)dateTimePicker_GuestIn.Value;
            guest.G_in_date = dateTimePicker_GuestIn.Value;
            //guest.G_out_date = (DateTime)dateTimePicker_GuestOut.Value;
            guest.G_out_date = dateTimePicker_GuestOut.Value;
            guest.G_other = richTextBox_GuestOther.Text;

            if (dateTimePicker_GuestIn.Value != null)
            {
                guest.G_in_date = dateTimePicker_GuestIn.Value;
            }
            if (dateTimePicker_GuestOut.Value != null)
            {
                guest.G_out_date = dateTimePicker_GuestOut.Value;
            }






            Program.database.insertGuest(guest);
            this.Close();
            */
        }

        private void updateGuest(object sender, EventArgs e)
        {   /*
            if (selectedGuest != null)
            //if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                //Guest selectedGuestName = (Guest)Program.formChoice.listBox_Choice.SelectedItem;

                selectedGuest.G_name = textBox_GuestName.Text;
                selectedGuest.G_chip = textBox_GuestChip.Text;
                selectedGuest.G_in_place = textBox_GuestWhere.Text;
                selectedGuest.G_species = comboBox_GuestSpecies.Text;
                selectedGuest.G_gender = comboBox_GuestGender.Text;
                selectedGuest.G_adoption = comboBox_GuestAdoption.Text;
                selectedGuest.G_in_date = (DateTime)dateTimePicker_GuestIn.Value;
                selectedGuest.G_out_date = (DateTime)dateTimePicker_GuestOut.Value;
                selectedGuest.G_other = richTextBox_GuestOther.Text;

                Program.database.updateGuest(selectedGuest);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }

        private void deleteGuest(object sender, EventArgs e)
        {   
            /*
            if (selectedGuest != null)
            //if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                //Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;
                Program.database.deleteGuest(selectedGuest);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }

        //*************************

        private void button_GuestInsert_Click(object sender, EventArgs e)
        {
            Guest guest = new Guest();

            guest.G_name = textBox_GuestName.Text;
            guest.G_chip = textBox_GuestChip.Text;
            guest.G_in_place = textBox_GuestWhere.Text;
            guest.G_species = comboBox_GuestSpecies.Text;
            guest.G_gender = comboBox_GuestGender.Text;
            guest.G_adoption = comboBox_GuestAdoption.Text;
            //guest.G_in_date = (DateTime)dateTimePicker_GuestIn.Value;
            guest.G_in_date = dateTimePicker_GuestIn.Value;
            //guest.G_out_date = (DateTime)dateTimePicker_GuestOut.Value;
            guest.G_out_date = dateTimePicker_GuestOut.Value;
            guest.G_other = richTextBox_GuestOther.Text;

            if (dateTimePicker_GuestIn.Value != null)
            {
                guest.G_in_date = dateTimePicker_GuestIn.Value;
            }
            if (dateTimePicker_GuestOut.Value != null)
            {
                guest.G_out_date = dateTimePicker_GuestOut.Value;
            }
            Program.database.insertGuest(guest);
            emptyFieldsGuest();
            uploadData();     //  2. nál fennálló problémát nem oldja meg "parameter mar meg van határozva"


            this.Close();
        }

        private void button_GuestUpdate_Click(object sender, EventArgs e)
        {
            if (selectedGuest != null)
            //if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                //Guest selectedGuestName = (Guest)Program.formChoice.listBox_Choice.SelectedItem;

                selectedGuest.G_name = textBox_GuestName.Text;
                selectedGuest.G_chip = textBox_GuestChip.Text;
                selectedGuest.G_in_place = textBox_GuestWhere.Text;
                selectedGuest.G_species = comboBox_GuestSpecies.Text;
                selectedGuest.G_gender = comboBox_GuestGender.Text;
                selectedGuest.G_adoption = comboBox_GuestAdoption.Text;
                selectedGuest.G_in_date = (DateTime)dateTimePicker_GuestIn.Value;
                selectedGuest.G_out_date = (DateTime)dateTimePicker_GuestOut.Value;
                selectedGuest.G_other = richTextBox_GuestOther.Text;

                Program.database.updateGuest(selectedGuest);
                emptyFieldsGuest();
                uploadData();     //  2. nál fennálló problémát nem oldja meg "parameter mar meg van határozva"

                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_GuestDelete_Click(object sender, EventArgs e)
        {
            if (selectedGuest != null)
            //if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                //Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;
                Program.database.deleteGuest(selectedGuest);
                emptyFieldsGuest();
                uploadData();     //  2. nál fennálló problémát nem oldja meg "parameter mar meg van határozva"

                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
