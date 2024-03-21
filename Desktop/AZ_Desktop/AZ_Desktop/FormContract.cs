using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AZ_Desktop
{
    public partial class FormContract : Form
    {
        public FormContract()
        {
            InitializeComponent();
        }

        public void OpenPDFWithEdge(string filePath)
        {
            try
            {
                Process.Start("msedge.exe", $"\"{filePath}\"");
            }
            catch (Exception ex)
            {
                // Kezeljük a hibát, ha valami nem sikerült
                Console.WriteLine("Hiba történt a PDF megnyitása során: " + ex.Message);
            }
        }

        private void button_OpenPDF_Click(object sender, EventArgs e)
        {
        //C: \Users\Zita\Desktop\VIZSGAREMEK\AZ_Menhely\Desktop\AZ_Desktop
            string filePath = "C:C: \\Users\\Zita\\Desktop\\VIZSGAREMEK\\AZ_Menhely\\Desktop\\AZ_Desktop.pdf"; // Az elérési útvonalat helyettesítsd a saját fájlod elérési útvonalával

            OpenPDFWithEdge(filePath);
        }

        //****************************
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
