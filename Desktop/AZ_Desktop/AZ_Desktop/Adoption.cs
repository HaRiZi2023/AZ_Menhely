using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Desktop
{
    internal class Adoption
    {
        int id;
        DateTime a_date;
        string g_name;
        string u_name;
        DateTime created_at;
        DateTime updated_at;

        public Adoption() // + konstruktor (itt nem üres, de az szokott)
        {
            this.Created_at = DateTime.Now; // Az objektum létrehozásának időpontja
            this.Updated_at = DateTime.Now; // Az utolsó frissítés időpontja
        }

        public Adoption(int id, DateTime a_date, string g_name, string u_name, DateTime created_at, DateTime updated_at)
        {
            this.Id = id;
            this.A_date = a_date;
            this.G_name = g_name;
            this.U_name = u_name;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }
        // Tulajdonságok

        public int Id { get => id; set => id = value; }
        public DateTime A_date { get => a_date; set => a_date = value; }
        public string G_name { get => g_name; set => g_name = value; }
        public string U_name { get => u_name; set => u_name = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
       
    }
}
