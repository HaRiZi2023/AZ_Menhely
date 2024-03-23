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
            //button_ContractPDF.Click += button_ContractPDF_Click;
        }

        private void FormContract_Load(object sender, EventArgs e)
        {
        }

        private void button_ContractPDF_Click(object sender, EventArgs e)
        {
           // string filePath = @"C:\Users\Zita\Desktop\VIZSGAREMEK\AZ_Menhely\Desktop\AZ_Desktop.pdf"; // A PDF fájl elérési útvonalának beállítása

            //OpenPDFWithEdge(filePath);
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
        /*
        public static void Main()
        {
            //Application.Run(new FormContact());
        }
        */
    }
}
