using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AZ_Desktop
{
    internal class Database
    {
        MySqlConnection conn = null;
        MySqlCommand sql = null;

        public Database()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "menhely";
            builder.CharacterSet = "utf8";
            conn = new MySqlConnection(builder.ConnectionString);
            sql = conn.CreateCommand();
            try
            {
                connOpening();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            finally
            {
                connClosing();
            }
        }

        private void connOpening()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void connClosing()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        //***********chip********************/

        public DataTable ExecuteQuery(string query, object parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    if (parameters != null)
                    {
                        // Paraméterek hozzáadása a lekérdezéshez
                        foreach (var prop in parameters.GetType().GetProperties())
                        {
                            cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
                        }
                    }

                    conn.Open();
                    // Lekérdezés végrehajtása és az eredmények lekérdezése
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            finally
            {
                conn.Close();
            }

            return dataTable;
        }


        //**********************************************************************************

        //**************  workers  **********************

        internal List<Worker> getAllWorker() // ezt a Program.cs ben adom meg
        {
            List<Worker> workers = new List<Worker>();
            sql.CommandText = "SELECT * FROM `workers` ORDER BY `w_name`";  // ok
            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string w_name = dr.GetString("w_name");
                        string w_password = dr.GetString("w_password");
                        string w_permission = dr.GetString("w_permission"); //enum



                        workers.Add(new Worker(id, w_name, w_password, w_permission));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
            return workers;
        }

        internal void insertWorker(Worker worker)
        {
            try
            {
                connOpening();

                sql.CommandText = "INSERT INTO `workers` (`id`, `w_name`, `w_password`, `w_permission`) VALUES (`@w_id`, `@w_name`, `@w_password`, `@w_permission`) ";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@id", worker.Id);
                sql.Parameters.AddWithValue("@w_name", worker.W_name);
                sql.Parameters.AddWithValue("@w_password", worker.W_password);
                sql.Parameters.AddWithValue("@w_permission", worker.W_permission);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
        }

        internal void updateWorker(Worker worker)  //ok
        {
            try
            {
                connOpening();

                sql.CommandText = "UPDATE `workers` SET `id`=@id,`w_password`=@w_password,`w_permission`=@w_permission,`, WHERE `g_name`=@g_name";


                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@id", worker.Id);
                sql.Parameters.AddWithValue("@w_name", worker.W_name);
                sql.Parameters.AddWithValue("@w_password", worker.W_password);
                sql.Parameters.AddWithValue("@w_permission", worker.W_permission);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
        }

        internal void deleteWorker(Worker worker)
        {
            try
            {
                connOpening();

                sql.CommandText = "DELETE FROM `workers` WHERE `name`= @name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("w_name", worker.W_name);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
        }

        //************* Choice **************************** 

        internal List<Guest> AllDog() // ezt a Program.cs ben adom meg
        {
            List<Guest> dogs = new List<Guest>();
            sql.CommandText = "SELECT * FROM guests WHERE g_species = @kutya ";  // ok
            sql.Parameters.AddWithValue("@kutya", "kutya");

            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string g_name = dr.GetString("g_name");
                        string g_chip = dr.GetString("g_chip");
                        string g_species = dr.GetString("g_species");
                        string g_gender = dr.GetString("g_gender"); //enum
                        DateTime g_in_date = dr.GetDateTime("g_in_date");
                        string g_in_place = dr.GetString("g_in_place");
                        DateTime g_out_date = dr.GetDateTime("g_out_date");
                        string g_adoption = dr.GetString("g_adoption");
                        string g_other = dr.GetString("g_other");  //enum
                        string g_images = dr.GetString("g_images");

                        dogs.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_images));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
            return dogs;
        }

        internal List<Guest> AllCat() // ezt a Program.cs ben adom meg
        {
            List<Guest> cats = new List<Guest>();
            sql.CommandText = "SELECT * FROM guests WHERE g_species = @macska ";  // ok
            sql.Parameters.AddWithValue("@macska", "macska");

            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string g_name = dr.GetString("g_name");
                        string g_chip = dr.GetString("g_chip");
                        string g_species = dr.GetString("g_species");
                        string g_gender = dr.GetString("g_gender"); //enum
                        DateTime g_in_date = dr.GetDateTime("g_in_date");
                        string g_in_place = dr.GetString("g_in_place");
                        DateTime g_out_date = dr.GetDateTime("g_out_date");
                        string g_adoption = dr.GetString("g_adoption"); //enum
                        string g_other = dr.GetString("g_other");  
                        string g_images = dr.GetString("g_images");

                        cats.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_images));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
            return cats;
        }

        //***************** guests ****************
        internal List<Guest> allGuest() // ezt a Program.cs ben adom meg
        {
            List<Guest> guests = new List<Guest>();
            sql.CommandText = "SELECT * FROM `guests` ORDER BY `g_name`";  // ok
            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string g_name = dr.GetString("g_name");
                        string g_chip = dr.GetString("g_chip");
                        string g_species = dr.GetString("g_species");
                        string g_gender = dr.GetString("g_gender"); //enum
                        DateTime g_in_date = dr.GetDateTime("g_in_date");
                        string g_in_place = dr.GetString("g_in_place");
                        DateTime g_out_date = dr.GetDateTime("g_out_date");
                        string g_adoption = dr.GetString("g_adoption");
                        string g_other = dr.GetString("g_other");  //enum
                        string g_images = dr.GetString("g_images");

                        guests.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_images));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
            return guests;
        }

        internal void insertGuest(Guest guest)
        {
            try
            {
                connOpening();

                sql.CommandText = "INSERT INTO `guests` (`g_name`,`g_chip`,`g_species`,`g_gender`,`g_in_date`,`g_in_place`,`g_out_date`,`g_adoption`,`g_other`,`g_images`) VALUES (@g_name, @g_chip, @g_species, @g_gender, @g_in_date, @g_in_place, @g_out_date, @g_adoption, @g_other, @g_images)";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@g_name", guest.G_name);
                sql.Parameters.AddWithValue("@g_chip", guest.G_chip);
                sql.Parameters.AddWithValue("@g_species", guest.G_species);
                sql.Parameters.AddWithValue("@g_gender", guest.G_gender);
                sql.Parameters.AddWithValue("@g_in_date", guest.G_in_date);
                sql.Parameters.AddWithValue("@g_in_place", guest.G_in_place);
                sql.Parameters.AddWithValue("@g_out_date", guest.G_out_date);
                sql.Parameters.AddWithValue("@g_adoption", guest.G_adoption);
                sql.Parameters.AddWithValue("@g_other", guest.G_other);
                sql.Parameters.AddWithValue("@g_images", guest.G_images);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
        }

        internal void updateGuest(Guest guest)
        {
            try
            {
                connOpening();

                sql.CommandText = "UPDATE `guests` SET `g_chip`=@g_chip,`g_species`=@g_species,`g_gender`=@g_gender,`g_in_date`= @g_in_date,`g_in_place`=@g_in_place,`g_out_date`=@g_out_date,`g_adoption`=@g_adoption,`g_other`=@g_other,`g_images`=@g_images WHERE `g_name`=@g_name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@g_name", guest.G_name);
                sql.Parameters.AddWithValue("@g_chip", guest.G_chip);
                sql.Parameters.AddWithValue("@g_species", guest.G_species);
                sql.Parameters.AddWithValue("@g_gender", guest.G_gender);
                sql.Parameters.AddWithValue("@g_in_date", guest.G_in_date);
                sql.Parameters.AddWithValue("@g_in_place", guest.G_in_place);
                sql.Parameters.AddWithValue("@g_out_date", guest.G_out_date);
                sql.Parameters.AddWithValue("@g_adoption", guest.G_adoption);
                sql.Parameters.AddWithValue("@g_other", guest.G_other);
                sql.Parameters.AddWithValue("@g_images", guest.G_images);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
        }


        internal void deleteGuest(Guest guest)
        {
            try
            {
                connOpening();

                sql.CommandText = "DELETE FROM `guests` WHERE `g_name`= @g_name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@g_name", guest.G_name);

                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connClosing();
            }
        }
 
    //************ Chip ****************//

        internal void updateChipOther(string chipNumber, string otherValue) 
        {
            connOpening();

            string query = "UPDATE guests SET g_other = @OtherValue WHERE g_chip = @ChipNumber";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OtherValue", otherValue);
                cmd.Parameters.AddWithValue("@ChipNumber", chipNumber);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Az adatok sikeresen frissítve lettek az adatbázisban.");
                }
                else
                {
                    MessageBox.Show("Hiba történt az adatok frissítése közben.");
                }
            }

            connClosing();

        }
    }
}
//**********************************************************************************












