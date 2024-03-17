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


        public static List<Worker> workers = new List<Worker>();
        public static FormLogin formLogin = null;

        public static List<CheckBox> checkBoxes = new List<CheckBox>();

        public static List<Guest> guests = new List<Guest>();
        public static FormMain formMain = null;

        public static FormChoice formChoice = null;
        public static FormGuest formGuest = null;

        public static FormAdoption formAdoption = null;

        //public static FormChip formChip = null;
        //public static FormTalalt formTalalt = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            database = new Database();

            //guests = database.getAllGuest(); //

            formLogin = new FormLogin();  // FormMAin példányosítása
            //workers = database.getAllWorker();

           Application.Run(new FormLogin());
        }
    }
}
