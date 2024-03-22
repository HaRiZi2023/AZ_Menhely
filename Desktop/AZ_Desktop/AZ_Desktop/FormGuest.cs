﻿using Google.Protobuf.WellKnownTypes;
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
    public partial class FormGuest : Form
    {
        private Database database;


        //string options;  //*
        public FormGuest()
        {
            InitializeComponent();
            database = new Database();
            //listBox_Choice.SelectedIndexChanged += listBox_Choice_SelectedIndexChanged; // Ez a sor fontos


            //this.options = options; //*
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {
            uploadData();
        }

        public void DisplayText(string text)  // ???
        {
            // Ide tedd azt a kódot, amely megjeleníti a kapott szöveget
            MessageBox.Show(text);
        }

        public void uploadData()  //*
        {
            if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;

                textBox_GuestName.Text = guest.G_name.ToString();
                textBox_GuestChip.Text = guest.G_chip.ToString();
                textBox_GuestWhere.Text = guest.G_in_place.ToString();
                comboBox_GuestSpecies.Text = guest.G_species.ToString();
                comboBox_GuestGender.Text = guest.G_gender.ToString();
                comboBox_GuestAdoption.Text = guest.G_adoption.ToString();
                dateTimePicker_GuestIn.Value = guest.G_in_date;
                dateTimePicker_GuestOut.Value = guest.G_out_date;
                richTextBox_GuestOther.Text = guest.G_other.ToString();
            }
        }

        private void insertGuest(object sender, EventArgs e)
        {
            Guest guest = new Guest();

            guest.G_name = textBox_GuestName.Text;
            guest.G_chip = textBox_GuestChip.Text;
            guest.G_in_place = textBox_GuestWhere.Text;
            guest.G_species = comboBox_GuestSpecies.Text;
            guest.G_gender = comboBox_GuestGender.Text;
            guest.G_adoption = comboBox_GuestAdoption.Text;
            guest.G_in_date = (DateTime)dateTimePicker_GuestIn.Value;
            guest.G_out_date = (DateTime)dateTimePicker_GuestOut.Value;
            guest.G_other = richTextBox_GuestOther.Text;

            Program.database.insertGuest(guest);
            this.Close();
        }

        private void updateGuest(object sender, EventArgs e)
        {
            if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;
                guest.G_name = textBox_GuestName.Text;
                guest.G_chip = textBox_GuestChip.Text;
                guest.G_in_place = textBox_GuestWhere.Text;
                guest.G_species = comboBox_GuestSpecies.Text;
                guest.G_gender = comboBox_GuestGender.Text;
                guest.G_adoption = comboBox_GuestAdoption.Text;
                guest.G_in_date = dateTimePicker_GuestIn.Value;
                guest.G_out_date = dateTimePicker_GuestOut.Value;
                guest.G_other = richTextBox_GuestOther.Text;

                Program.database.updateGuest(guest);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteGuest(object sender, EventArgs e)
        {
            if (Program.formChoice.listBox_Choice.SelectedItem != null)
            {
                Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;
                Program.database.deleteGuest(guest);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a ListBox-ban!", "Hiányzó kiválasztás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



















        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
