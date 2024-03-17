using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        private void connClosing()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private void connOpening()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
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

        //***************** guests ****************
        internal List<Guest> getAllGuest() // ezt a Program.cs ben adom meg
        {
            List<Guest> egyedek = new List<Guest>();
            sql.CommandText = "SELECT * FROM `guests` ORDER BY `g_species`";  // ok
            try
            {
                connOpening();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int g_id = dr.GetInt32("g_id");
                        string g_name = dr.GetString("g_name");
                        string g_chip = dr.GetString("g_chip");
                        string g_species = dr.GetString("g_species");
                        string g_gender = dr.GetString("g_gender"); //enum
                        DateTime g_in_date = dr.GetDateTime("g_in_date");
                        string g_in_place = dr.GetString("g_in_place");
                        DateTime g_out_date = dr.GetDateTime("g_out_date");
                        string g_adoption = dr.GetString("g_adoption");
                        string g_other = dr.GetString("g_other");  //enum


                        egyedek.Add(new Guest(g_id, g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other));
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
            return egyedek;
        }

        internal void insertEgyed(Guest egyed)
        {
            try
            {
                connOpening();

                sql.CommandText = "INSERT INTO `guests` (`g_id`, `g_name`, `g_chip`, `g_species`, `g_gender`, `g_in_date`, `g_in_place`, `g_out_date`, `g_adoption`, `g_other`) VALUES (`@g_id`, `@g_name`, `@g_chip`, `@g_species`, `@g_gender`, `@g_in_date`, `@g_in_place`, `@g_out_date`, `@g_adoption`, `@g_other`) ";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@g_id", egyed.G_id);
                sql.Parameters.AddWithValue("@g_name", egyed.G_name);
                sql.Parameters.AddWithValue("@g_chip", egyed.G_chip);
                sql.Parameters.AddWithValue("@g_species", egyed.G_species);
                sql.Parameters.AddWithValue("@g_gender", egyed.G_gender);
                sql.Parameters.AddWithValue("@g_in_date", egyed.G_in_date);
                sql.Parameters.AddWithValue("@g_in_place", egyed.G_in_place);
                sql.Parameters.AddWithValue("@g_out_date", egyed.G_out_date);
                sql.Parameters.AddWithValue("@g_adoption", egyed.G_adoption);
                sql.Parameters.AddWithValue("@g_other", egyed.G_other);
                //sql.Parameters.AddWithValue("@g_IMAGES, egyed.G_IMAGES);

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

        internal void updateEgyed(Guest egyed)  //ok
        {
            try
            {
                connOpening();

                sql.CommandText = "UPDATE `guests` SET `g_id`=@g_id,`g_chip`=@g_chip,`g_species`=@g_species,`g_gender`=@g_gender,`g_in_date`=@g_in_date,`g_in_place`=@g_in_place,`g_out_date`=@g_out_date, `g_adoption`=@g_adoption,`g_other`=@g_other, WHERE `g_name`=@g_name";


                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("@g_id", egyed.G_id);
                sql.Parameters.AddWithValue("@g_name", egyed.G_name);
                sql.Parameters.AddWithValue("@g_chip", egyed.G_chip);
                sql.Parameters.AddWithValue("@g_species", egyed.G_species);
                sql.Parameters.AddWithValue("@g_gender", egyed.G_gender);
                sql.Parameters.AddWithValue("@g_in_date", egyed.G_in_date);
                sql.Parameters.AddWithValue("@g_in_place", egyed.G_in_place);
                sql.Parameters.AddWithValue("@g_out_date", egyed.G_out_date);
                sql.Parameters.AddWithValue("@g_adoption", egyed.G_adoption);
                sql.Parameters.AddWithValue("@g_other", egyed.G_other);
                //sql.Parameters.AddWithValue("@g_IMAGES, egyed.G_IMAGES);

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

        internal void deleteEgyed(Guest egyed)
        {
            try
            {
                connOpening();

                sql.CommandText = "DELETE FROM `guests` WHERE `name`= @name";

                sql.Parameters.Clear();

                sql.Parameters.AddWithValue("g_name", egyed.G_name);

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
