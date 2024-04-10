using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Desktop
{
    static class Program
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

        public static FormFound formFound = null;
        public static List<Found> founds = new List<Found>();



        public static FormAdoption formAdoption = null;
        public static List<Adoption> adoptables = new List<Adoption>();
        public static List<User> users = new List<User>();

        public static FormChip formChip = null;


        //   // public static FormChip user = null;  



        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // Ezzel állítjuk be az STA módot
        static void Main()
        {
            /*
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("http://localhost:8000/api/endpoint");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"HTTP Error: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"HTTP Request Error: {e.Message}");
                }
            }
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //formLogin = new FormLogin();  // Ezt nem ,de minden más példányosítása

            formAdoption = new FormAdoption();
            formChip = new FormChip();
            formChoice = new FormChoice();
            //formExit = new FormExit();
            formFound = new FormFound();
            //formGuest = new FormGuest();
            formMain = new FormMain();
            formLogin = new FormLogin();
          
            
            //database = new Database();
            formChoice = new FormChoice();
            //formGuest = new FormGuest();


            

            //FormLogin formLogin = new FormLogin();
            Application.Run(new FormLogin());
        }
    }
}



