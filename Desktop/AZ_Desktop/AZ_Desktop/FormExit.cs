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
    public partial class FormExit : Form
    {
        private Timer timer;
        public FormExit()
        {
            InitializeComponent();

            // a Controlbox elrejtése (ne legyen close button!)
            this.ControlBox = false;
        }

        private void FormExit_Load(object sender, EventArgs e)
        {

        }

        private void button_ExitYes_Click(object sender, EventArgs e)
        {
            label_ExitQuestion.Text = "";
            button_ExitYes.Visible = false;
            button_ExitNo.Visible = false;

            // Megjelenítjük az üzenetet
            label_ExitBye.Visible = true;

            // Létrehozzuk és beállítjuk az időzítőt
            timer = new Timer();
            timer.Interval = 5000; // 5 másodperc
            timer.Tick += Timer;
            timer.Start();
        }




        private void Timer(object sender, EventArgs e)
        {
            // Ha az időzítő lejárt bezáródik az alkalmazás
            Application.Exit();
        }

        private void button_ExitNo_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            /*formMain.FormClosed += (obj, args) =>
            {
                this.Show();
            };*/
            formMain.Show();
        }
    }
}
