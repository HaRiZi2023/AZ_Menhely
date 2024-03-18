using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Desktop
{
    public partial class FormGuest : Form
    {
        public FormGuest()
        {
            InitializeComponent();
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {

        }

        public void functionDisplay(string text)
        {
            // Korábbi gomb szövegének beállítása
            label_GuestFunction.Text = text;    //label_GuestFunction
        }
       
        public void guestDataTransfer()                ////////////////////////////////////////////
        {
            // Például, ha van egy textBox a nevű TextBox a FormGuest formon, akkor beállíthatjuk az adatokat így:

            Guest guest = (Guest)Program.formChoice.listBox_Choice.SelectedItem;
          
            textBox_GuestName.Text = guest.G_name.ToString();
            textBox_GuestChip.Text = guest.G_chip.ToString();
            textBox_GuestWhere.Text = guest.G_in_place.ToString();
            comboBox_GuestSpecies.Text = guest.G_species.ToString();
            comboBox_GuestGender.Text = guest.G_gender.ToString();
            comboBox_GuestAdoption.Text = guest.G_adoption.ToString();
            //comboBox_GuestInjury.Text = guest.G_injury.ToString();
            dateTimePicker_GuestIn.Value = guest.G_in_date;
            dateTimePicker_GuestOut.Value = guest.G_out_date;
            richTextBox_GuestOther.Text = guest.G_other.ToString();
            // Hasonló módon beállíthatjuk a többi adatot is
            // ...

            /* // Ha van ListBox a FormGuest formon, és például a vendégnek van egy listája adatairól, akkor azt is feltölthetjük:
             listBox_Guest.Items.Clear(); // Először töröljük az előző adatokat
             foreach (var item in guest.DataList)
             {
                 listBox_Guest.Items.Add(item);
             }*/
        } 

       
        













        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
