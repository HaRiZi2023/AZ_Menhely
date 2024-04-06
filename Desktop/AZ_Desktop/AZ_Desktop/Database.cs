﻿using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

                //******* nekem segítség, hogy kiírja ha nincs adatbázis kapcsolat. Majd törlendő
                
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Adatbáziskapcsolat létrehozva és megnyitva.", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nem sikerült megnyitni az adatbáziskapcsolatot.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //******* nekem segítség, hogy kiírja ha nincs adatbázis kapcsolat.

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

        //**************  workers  **********************

        internal List<Worker> allWorker() // ezt a Program.cs ben adom meg
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
                        DateTime created_at = DateTime.Now;
                        DateTime updated_at = DateTime.Now;


                        workers.Add(new Worker(id, w_name, w_password, w_permission, created_at, updated_at));
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

                sql.CommandText = "INSERT INTO `workers` (`w_name`, `w_password`, `w_permission`, `created_at`, `updated_at`) VALUES (@w_name, @w_password, @w_permission, @created_at , @updated_at) ";

                sql.Parameters.Clear();

               
                sql.Parameters.AddWithValue("@w_name", worker.W_name);
                sql.Parameters.AddWithValue("@w_password", worker.W_password);
                sql.Parameters.AddWithValue("@w_permission", worker.W_permission);
                sql.Parameters.AddWithValue("@created_at", worker.Created_at);
                sql.Parameters.AddWithValue("@updated_at", worker.Updated_at);

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

        internal bool CheckWorkerExists(string workerName) //up és delhez
        {
            try
            {
                connOpening();

                sql.CommandText = "SELECT COUNT(*) FROM `workers` WHERE `w_name` = @w_name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@w_name", workerName);

                int count = Convert.ToInt32(sql.ExecuteScalar());

                return count > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connClosing();
            }
        }

        internal void updateWorker(string workerNameUpdate, string workerPasswordUpdate, string workerPermissionUpdate)  
        {
            try
            {
                connOpening();

                sql.CommandText = "UPDATE `workers` SET `w_password`=@workerPasswordUpdate,`w_permission`=@workerPermissionUpdate WHERE `w_name`=@workerNameUpdate";


                sql.Parameters.Clear();

                //sql.Parameters.AddWithValue("@id", worker.Id);
                
                sql.Parameters.AddWithValue("@workerPasswordUpdate", workerPasswordUpdate);
                sql.Parameters.AddWithValue("@workerPermissionUpdate", workerPermissionUpdate);
                sql.Parameters.AddWithValue("@workerNameUpdate", workerNameUpdate);
                
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

        internal void deleteWorker(string workerName)
        {
            try
            {
                connOpening();

                sql.CommandText = "DELETE FROM `workers` WHERE `w_name`= @w_name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("w_name", workerName);

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

        internal List<Guest> allDog() // ezt a Program.cs ben adom meg
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

                        byte[] g_image = (byte[])dr["g_image"];

                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");

                        dogs.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at, updated_at));
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

        internal List<Guest> allCat() // ezt a Program.cs ben adom meg
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

                        byte[] g_image = (byte[])dr["g_image"];

                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");


                        cats.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at,updated_at));
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

        internal Guest chosenName(string G_name) //kiválasztott név adatainak lekérdezése                      name
        {
            Guest selectedGuest = null;

            try
            {
                connOpening();

                sql.CommandText = "SELECT * FROM `guests` WHERE `g_name` = @g_name";
                sql.Parameters.AddWithValue("@g_name", G_name);  // name votl

                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string g_name = dr.GetString("g_name");
                        string g_chip = dr.GetString("g_chip");
                        string g_species = dr.GetString("g_species");
                        string g_gender = dr.GetString("g_gender");
                        DateTime g_in_date = dr.GetDateTime("g_in_date");
                        string g_in_place = dr.GetString("g_in_place");
                        DateTime g_out_date = dr.GetDateTime("g_out_date");
                        string g_adoption = dr.GetString("g_adoption");
                        string g_other = dr.GetString("g_other");

                        byte[] g_image = (byte[])dr["g_image"];

                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");

                        selectedGuest = new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at, updated_at);
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

            return selectedGuest;
        }

        //***************** guests ****************

        public byte[] ImageToByteArray(Image imageIn) // kell-e
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        internal bool CheckGuestExists(string guestName) //up és delhez is
        {
            try
            {
                connOpening();

                sql.CommandText = "SELECT COUNT(*) FROM `guests` WHERE `g_name` = @g_name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@g_name", guestName);

                int count = Convert.ToInt32(sql.ExecuteScalar()); // mit 

                return count > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connClosing();
            }
        }

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
                        int id = dr.GetInt32("id"); // bigint??
                        string g_name = dr.GetString("g_name");
                        string g_chip = dr.GetString("g_chip");
                        string g_species = dr.GetString("g_species");
                        string g_gender = dr.GetString("g_gender"); //enum
                        DateTime g_in_date = dr.GetDateTime("g_in_date");
                        string g_in_place = dr.GetString("g_in_place");
                        DateTime g_out_date = dr.GetDateTime("g_out_date");
                        string g_adoption = dr.GetString("g_adoption");
                        string g_other = dr.GetString("g_other");  //enum
                        
                        byte[] g_image = (byte[])dr["g_image"];

                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");

                        guests.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at, updated_at));
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

                sql.CommandText = "INSERT INTO `guests` (`g_name`,`g_chip`,`g_species`,`g_gender`,`g_in_date`,`g_in_place`,`g_out_date`,`g_adoption`,`g_other`,`g_image`, `created_at`, `updated_at`) VALUES (@g_name, @g_chip, @g_species, @g_gender, @g_in_date, @g_in_place, @g_out_date, @g_adoption, @g_other, @g_image, @created_at, @updated_at)";

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


                sql.Parameters.AddWithValue("@g_image", guest.G_image);


                //byte[] imageBytes = Convert.FromBase64String(guest.G_image);
                //sql.Parameters.AddWithValue("@g_image", imageBytes);
               

                sql.Parameters.AddWithValue("@created_at", guest.Created_at);
                sql.Parameters.AddWithValue("@updated_at", guest.Updated_at);
                /*
                // Kép byte tömbbé alakítása
                byte[] imageBytes = ImageToByteArray(guest.G_image);
                sql.Parameters.AddWithValue("@g_image", imageBytes);*/

               


                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hiba történt az adatok mentése közben: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                sql.CommandText = "UPDATE `guests` SET `g_chip`=@g_chip,`g_species`=@g_species,`g_gender`=@g_gender,`g_in_date`= @g_in_date,`g_in_place`=@g_in_place,`g_out_date`=@g_out_date,`g_adoption`=@g_adoption,`g_other`=@g_other,`g_image`=@g_image WHERE `g_name`=@g_name";

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

                sql.Parameters.AddWithValue("@g_image", guest.G_image);

                sql.Parameters.AddWithValue("@created_at", guest.Created_at);
                sql.Parameters.AddWithValue("@updated_at", guest.Updated_at);


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

        //************* Found ****************************

        internal List<Found> allFound() // ezt a Program.cs ben adom meg
        {
            List<Found> founds = new List<Found>();
            sql.CommandText = "SELECT * FROM `founds` ORDER BY `id`";  // ok
            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string f_choice = dr.GetString("f_choice");
                        string f_species = dr.GetString("f_species");
                        string f_gender = dr.GetString("f_gender");
                        string f_injury = dr.GetString("f_injury");
                        string f_position = dr.GetString("f_position");
                        string f_other = dr.GetString("f_other"); 
                        
                        byte[] f_image = (byte[])dr["f_image"];

                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");

                        founds.Add(new Found(id, f_choice, f_species, f_gender, f_injury, f_position, f_other, f_image, created_at, updated_at));
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
            return founds;
        }

        internal void insertFound(Found found)  // EZ NEM KELL!!!!!!!!!!
        {
            try
            {
                connOpening();

                sql.CommandText = "INSERT INTO `founds` (`f_choice`,`f_species`,`f_gender`,`f_injury`,`f_position`, `f_other`,`f_image`) VALUES ( @f_choice, @f_species, @f_gender, @f_injury, @f_position, @f_other, @f_image)";

                sql.Parameters.Clear();
                               
                sql.Parameters.AddWithValue("@f_choice", found.F_choice);
                sql.Parameters.AddWithValue("@f_species", found.F_species);
                sql.Parameters.AddWithValue("@f_gender", found.F_gender);
                sql.Parameters.AddWithValue("@f_injury", found.F_injury);
                sql.Parameters.AddWithValue("@f_position", found.F_position);
                sql.Parameters.AddWithValue("@f_other", found.F_other);
                sql.Parameters.AddWithValue("@f_image", found.F_image);

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

        internal void updateFound(Found found)
        {
            try
            {
                connOpening();

                sql.CommandText = "UPDATE `founds` SET `f_choice`=@f_choice,`f_species`=@f_species,`f_gender`=@f_gender,`f_injury`= @f_injury,`f_position`=@f_position,`f_other`=@f_other,`f_image`=@f_image WHERE `id`=@id";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@id", found.Id); 
                sql.Parameters.AddWithValue("@f_choice", found.F_choice);
                sql.Parameters.AddWithValue("@f_species", found.F_species);
                sql.Parameters.AddWithValue("@f_gender", found.F_gender);
                sql.Parameters.AddWithValue("@f_injury", found.F_injury);
                sql.Parameters.AddWithValue("@f_position", found.F_position);
                sql.Parameters.AddWithValue("@f_other", found.F_other);
                sql.Parameters.AddWithValue("@f_image", found.F_image);

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

        internal void deleteFound(Found found)
        {
            try
            {
                connOpening();

                sql.CommandText = "DELETE FROM `founds` WHERE `id`= @id";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@id", found.Id);

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

        //********** adoption ***************

        internal List<Guest> allAdoptableAnimal()
        {
            List<Guest> adoptables = new List<Guest>();
            sql.CommandText = "SELECT * FROM `guests` WHERE `g_adoption` = \"igen\"; ";   // ok
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
                        string g_other = dr.GetString("g_other");  

                        byte[] g_image = (byte[])dr["g_image"];

                        DateTime created_at = dr.GetDateTime("created_at");
                        DateTime updated_at = dr.GetDateTime("updated_at");

                        adoptables.Add(new Guest(id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at, updated_at));    /*g_image*/
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return adoptables; // Visszaadunk egy üres listát hiba esetén
            }
            finally
            {
                connClosing();
            }
            return adoptables;
        }

        internal List<User> allUser()
        {
            List<User> users = new List<User>();
            sql.CommandText = "SELECT * FROM `users` ORDER BY `name`";  // ok
            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        string name = dr.GetString("name");
                        string email = dr.GetString("email");
                        string password = dr.GetString("password");
                        string address = dr.GetString("address");
                        int phone = dr.GetInt32("phone");

                        users.Add(new User(id, name, email, password, address, phone));
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
            return users;
        }

        internal void adoptionStatusChange(Guest guest) // nem-re állításhoz
        { 
            try
            {
                connOpening();

                sql.CommandText = "UPDATE `guests` SET`g_adoption`= @g_adoption WHERE `g_name`=@g_name";

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
                sql.Parameters.AddWithValue("@g_image", guest.G_image);
               

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

        internal void insertAdoption(Adoption adoption)
        {
            try
            {
                connOpening();

                sql.CommandText = "INSERT INTO `adoptions` (`a_date`,`g_name`,`u_name`, `created_at`, `updated_at`) VALUES ( @a_date, @g_name, @u_name, @created_at, @updated_at)";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@a_date", adoption.A_date);
                sql.Parameters.AddWithValue("@g_name", adoption.G_name);
                sql.Parameters.AddWithValue("@u_name", adoption.U_name);
                sql.Parameters.AddWithValue("@created_at", adoption.Created_at);
                sql.Parameters.AddWithValue("@updated_at", adoption.Updated_at);
               
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

        internal void updateAdoption(Adoption adoption) //NEM KELL !!!!!!!
        {
            try
            {               
                connOpening();

                sql.CommandText = "UPDATE `adoptions` SET `a_date` = @a_date,`g_name` = @g_name,`u_name` = @u_name WHERE `id`=@id";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@a_date", adoption.A_date);
                sql.Parameters.AddWithValue("@g_name", adoption.G_name);
                sql.Parameters.AddWithValue("@u_name", adoption.U_name);

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

        internal void deleteAdoption(Adoption adoption) //NEM KELL !!!!!!!
        {
            try
            {
                connOpening();

                sql.CommandText = "DELETE FROM `adoptions` WHERE `id`= @id";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@id", adoption.Id);

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
    }
}
    
//**********************************************************************************












