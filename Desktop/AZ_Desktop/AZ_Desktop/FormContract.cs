using System; //
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;  //
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //
using System.Diagnostics; //-------
using iTextSharp.text.pdf;  //
using iTextSharp.text;  //
using System.IO;  //


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
            // FormContract képének elmentése
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            string imagePath = @"C:\Users\Zita\Desktop\contract_image.jpg";
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            // PDF fájl elérési útvonalának és nevének generálása
            string pdfFileName = $"contract_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
            string pdfFilePath = Path.Combine(@"C:\Users\Zita\Desktop\", pdfFileName);

            // PDF létrehozása és tartalom hozzáadása
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
            document.Open();
            document.Add(new Paragraph("Ez egy példa PDF generálásra az iTextSharp segítségével."));

            // Hozzáadhatod a képet a PDF-hez, ha szeretnéd
            // Image img = Image.GetInstance(imagePath);
            // document.Add(img);

            document.Close();

            // PDF megnyitása alapértelmezett PDF olvasó alkalmazásban
            System.Diagnostics.Process.Start(pdfFilePath);
        }







        /*
        string pdfFilePath = @"C:\Users\Zita\Desktop\VIZSGAREMEK\Desktop egyeb.pdf"; // A PDF fájl mentési helyének beállítása

        // PDF létrehozása és tartalom hozzáadása
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
        document.Open();
        document.Add(new Paragraph("Ez egy példa PDF generálásra az iTextSharp segítségével."));
        document.Close();

        // PDF megnyitása alapértelmezett PDF olvasó alkalmazásban
        System.Diagnostics.Process.Start(pdfFilePath);



        // PDF létrehozása és tartalommal való feltöltése
        // CreatePdf(filePath);

        MessageBox.Show("PDF fájl létrehozva: " + pdfFilePath , "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // string filePath = @"C:\Users\Zita\Desktop\VIZSGAREMEK\AZ_Menhely\Desktop\AZ_Desktop.pdf"; // A PDF fájl elérési útvonalának beállítása

        //OpenPDFWithEdge(filePath);

       
    }*/
        /*
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
        } */      
    }
}
