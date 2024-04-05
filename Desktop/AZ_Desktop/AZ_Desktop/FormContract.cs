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
using iTextSharp.text.pdf;
using iTextSharp.text;  
using System.IO;  
using System.Drawing.Imaging; 


namespace AZ_Desktop
{
    public partial class FormContract : Form
    {
        private Guest selectedAnimal;
        private User selectedUser;
       
        public FormContract(Guest selectedAnimal, User selectedUser)
        {
            InitializeComponent();
            this.selectedAnimal = selectedAnimal;
            this.selectedUser = selectedUser;
            uploadDataContract();                   //  
        }

        private void FormContract_Load(object sender, EventArgs e)
        {           
        }

        private void button_ContractPDF_Click(object sender, EventArgs e)
        {
            string animalName = selectedAnimal.G_name.Replace(" ", "_");
            string userName = selectedUser.Name.Replace(" ", "_");
            string imageName = $"contract_image_{userName}_{animalName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
            string imagePath = Path.Combine(@"C:\Users\Zita\Desktop\VIZSGAREMEK\", imageName);
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("A kép sikeresen el lett mentve: " + imagePath);

            /*
            //Csak JPG jól működik!!!
            // FormContract képének elmentése
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
            string imagePath = $@"C:\Users\Zita\Desktop\VIZSGAREMEK\contract_image_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("A kép sikeresen el lett mentve: " + imagePath);
            */


            /*
            // ez nem készít képet
            if (selectedAnimal != null && selectedUser != null)
            {
                string animalName = selectedAnimal.G_name.Replace(" ", "_");
                string userName = selectedUser.Name.Replace(" ", "_");
                string imageName = $"contract_image_{userName}_{animalName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";

                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                string imagePath = Path.Combine(@"C:\Users\Zita\Desktop\VIZSGAREMEK\", imageName);
                bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                MessageBox.Show("A kép sikeresen el lett mentve: " + imagePath);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott állat vagy felhasználó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        public void uploadDataContract()  // adat feltöltése () üres upload
        {
           
        }
        
        public void fillData(string animalName, string species, string gender, string chip, string userName, string address, string email, string phone, string date)
        {
            textBox_ContractGName.Text = animalName;
            textBox_ContractSpecies.Text = species;
            textBox_ContractChip.Text = chip;
            textBox_ContractGender.Text = gender;

            textBox_ContractUName.Text = userName;
            textBox_ContractAddress.Text = address;
            textBox_ContractEmail.Text = email;
            textBox_ContractPhone.Text = phone;
            textBox_ContractDate.Text = date;
        }
    }
}
