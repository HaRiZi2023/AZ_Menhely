using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace AZ_Desktop
{

    public partial class FormMain : Form
    {
        //private List<CheckBox> checkBoxes = new List<CheckBox>();
        private CheckBox[] checkBoxes_Main;

        public FormMain()
        {
            InitializeComponent();
            InitializeCheckBoxes_Main();

            


            /*checkBox_MainChoice.CheckedChanged += checkBox_CheckedChanged;
            checkBox_MainAdoption.CheckedChanged += checkBox_CheckedChanged;
            checkBox_MainFound.CheckedChanged += checkBox_CheckedChanged;
            checkBox_MainFound.CheckedChanged += checkBox_CheckedChanged; 

            foreach (var checkBox in checkBoxes)
            {
                checkBox.CheckedChanged += checkBox_CheckedChanged;
            }

            button_Main.Click += button_Main_Click;  */
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void InitializeCheckBoxes_Main()
        {
            checkBoxes_Main = new CheckBox[] { checkBox_MainChoice, checkBox_MainAdoption, checkBox_MainFound, checkBox_MainChip };

            // Előre beállítjuk a CheckBox-okat
            foreach (var checkBox in checkBoxes_Main)
            {
                checkBox.CheckedChanged += checkBox_CheckedChanged;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var clickedCheckBox = (CheckBox)sender;

            if (clickedCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes_Main)
                {
                    if (checkBox != clickedCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }
       
        private void button_Main_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e kiválasztott CheckBox
            bool anyChecked = false;
            CheckBox selectedCheckBox = null;

            foreach (var checkBox in checkBoxes_Main)
            {
                if (checkBox.Checked)
                {
                    if (anyChecked)
                    {
                        MessageBox.Show("Kérlek válassz ki csak egy CheckBox-ot!");
                        return;
                    }

                    anyChecked = true;
                    selectedCheckBox = checkBox;
                }
            }

            if (!anyChecked)
            {
                MessageBox.Show("Nincs kiválasztott CheckBox!", "Hiányzó bejelölés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

            switch (selectedCheckBox.Name)
            {
                case "checkBox_MainChoice":
                    FormChoice formChoice = new FormChoice();
                    formChoice.Show();
                    break;
                case "checkBox_MainAdoption":
                    FormAdoption formAdoption = new FormAdoption();
                    formAdoption.Show();
                    break;
                case "checkBox_MainFound":
                    FormFound formFound = new FormFound();
                    formFound.Show();
                    break;
                case "checkBox_MainChip":
                    FormChip formChip = new FormChip();
                    formChip.Show();
                    break;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ellenőrzöm, hogy az 'X' gombbal be akarták-e zárni az ablakot
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FormExit formExit = new FormExit();
                formExit.Show();

                // Add meg a kívánt viselkedést az ablak bezárásához
                // Például:
                //e.Cancel = true; // Megakadályozza az ablak bezárását
                // vagy:
                //this.Hide(); // Rejtse el az ablakot
            }
        }

        /*private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ellenőrzöm, hogy az 'X' gombbal be akarták-e zárni az ablakot
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FormExit formExit = new FormExit();
                formExit.Show();

                // Add meg a kívánt viselkedést az ablak bezárásához
                // Például:
                //e.Cancel = true; // Megakadályozza az ablak bezárását
                // vagy:
                //this.Hide(); // Rejtse el az ablakot
            }
        }*/




    }
}

