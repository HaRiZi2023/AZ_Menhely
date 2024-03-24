using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Desktop
{
    internal class Worker
    {
        int id;
        string w_name;
        string w_password;
        string w_permission;
        DateTime created_at;
        DateTime updated_at;

        public Worker() // Alapértelmezett konstruktor
        {
            this.Created_at = DateTime.Now; // Az objektum létrehozásának időpontja
            this.Updated_at = DateTime.Now; // Az utolsó frissítés időpontja
        }   
       
        public Worker(int id, string w_name, string w_password, string w_permission, DateTime created_at, DateTime updated_at)
        {
            this.Id = id;
            this.W_name = w_name;
            this.W_password = w_password;
            this.W_permission = w_permission;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }

        public int Id { get => id; set => id = value; }
        public string W_name { get => w_name; set => w_name = value; }
        public string W_password { get => w_password; set => w_password = value; }
        public string W_permission { get => w_permission; set => w_permission = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public override string ToString()
        {
            return $"{this.W_name}";
        }
    }
}
