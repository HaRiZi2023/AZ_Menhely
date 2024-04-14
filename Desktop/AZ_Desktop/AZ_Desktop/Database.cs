using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;

namespace AZ_Desktop
{
    internal class Database
    {
        HttpClient client = new HttpClient();
        string endPoint = ReadSetting("endPointUrl");

        
        private static string ReadSetting(string keyName)  // kiszerv
        {
            string result = null;
            try
            {
                var value = ConfigurationManager.AppSettings;
                result = value[keyName];
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        
        public Database()  // RR - Üres
        {

        }


        /***** fő *****/

        /*** chip ***/
        public static async Task<bool> CheckChipNumberInDatabase(string chipNumber) //Nem kell!!!!
        {
            HttpClient client = new HttpClient();
            string endPoint = ReadSetting("endPointUrl");

            try
            {
                string endPointGet = $"{endPoint}/guests/{chipNumber}";  // Az endpoint URL-jét az App.config.cs-ből olvassuk ki
                HttpResponseMessage response = await client.GetAsync(endPointGet);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);

                    return (bool)jsonResponse["exists"]; // A válasz JSON tartalmazza, hogy a chip szám szerepel-e az adatbázisban
                }
                else
                {
                    MessageBox.Show("Hiba történt az adatbázis ellenőrzése közben.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatbázis ellenőrzése közben: " + ex.Message);
                return false;
            }
        }

        internal static void updateChipOther(string chipNumber, string otherValue) //Nem kell!!!!
        {
            HttpClient client = new HttpClient();
            string endPoint = ReadSetting("endPointUrl");

            try
            {
                Guest guest = new Guest();

                //guest.G_other = richTextBox_GuestOther.Text;


                /*string endPointUpdate = $"{endPoint}/chip";
                var data = new Dictionary<string, string>
                    {
                        { "chipNumber", chipNumber },
                        { "otherValue", otherValue }
                    };

                var content = new FormUrlEncodedContent(data);

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatbázis frissítése közben: " + ex.Message);
            }
        }
    
        /*** ****/


    }
}   
    



