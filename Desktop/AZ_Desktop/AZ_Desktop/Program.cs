using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Desktop
{
    internal static class Program
    {
        public static Database database = null;

        public static FormLogin formLogin = null;
        public static List<Worker> workers = new List<Worker>();

        public static FormMain formMain = null;
        public static List<CheckBox> checkBoxes_Main = new List<CheckBox>();

        public static FormChoice formChoice = null;
        public static List<CheckBox> checkBoxes_Choice = new List<CheckBox>();
        public static List<Guest> dogs = new List<Guest>();
        public static List<Guest> cats = new List<Guest>();

        public static FormGuest formGuest = null;
        public static List<Guest> guests = new List<Guest>();



        public static FormAdoption formAdoption = null;
        
        public static FormFound formFound = null;
        
        public static FormChip formChip = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            database = new Database();

            formLogin = new FormLogin();  // FormLogin példányosítása

            //guests = database.getAllGuest(); // ezek nem kellenek induláskor
            //workers = database.getAllWorker();

            Application.Run(new FormLogin());
        }
    }
}
