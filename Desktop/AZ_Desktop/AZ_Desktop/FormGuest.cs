using Google.Protobuf.WellKnownTypes;
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
        string options;  //*
        public FormGuest()
        {
            InitializeComponent();
            this.options = options; //*
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {
            switch (options)  //*
            {
                case "add":
                    this.Text = "Felvitel";
                    button_GuestSending.Text = "Felvitel";
                    button_GuestSending.BackColor = Color.LightGreen;
                    button_GuestSending.Click += new EventHandler(insertGuest);
                    break;
                case "edit":
                    this.Text = "Módosítás";
                    button_GuestSending.Text = "Módosítás";
                    button_GuestSending.BackColor = Color.LightGreen;
                    button_GuestSending.Click += new EventHandler(updateGuest);
                    uploadData();
                    break;
                case "delete":
                    this.Text = "Törlés";
                    button_GuestSending.Text = "Törlés";
                    button_GuestSending.BackColor = Color.LightGreen;
                    button_GuestSending.Click += new EventHandler(deleteGuest);
                    uploadData();
                    break;
            }
        }

        private void uploadData()  //*
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

        private void deleteGuest(object sender, EventArgs e)
        {
            Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;
            Program.database.deleteGuest(guest);
            this.Close();
        }

        private void updateGuest(object sender, EventArgs e)
        {
            Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;

            guest.G_name = textBox_GuestName.Text; 
            guest.G_chip = textBox_GuestChip.Text; 
            guest.G_in_place = textBox_GuestWhere.Text; 
            guest.G_species = comboBox_GuestSpecies.Text; 
            guest.G_gender = comboBox_GuestGender.Text; 
            guest.G_adoption = comboBox_GuestAdoption.Text; 
            guest.G_in_date = (DateTime)dateTimePicker_GuestIn.Value;
            guest.G_out_date = (DateTime)dateTimePicker_GuestOut.Value; 
            guest.G_other = richTextBox_GuestOther.Text;

            Program.database.updateGuest(guest);
            this.Close();
        }

        private void insertGuest(object sender, EventArgs e)
        {
            Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;

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


















        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
