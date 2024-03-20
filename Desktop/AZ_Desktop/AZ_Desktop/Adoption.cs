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

        public Adoption(int id, DateTime a_date, string g_name, string u_name)
        {
            this.Id = id;
            this.A_date = a_date;
            this.G_name = g_name;
            this.U_name = u_name;
        }

        public int Id { get => id; set => id = value; }
        public DateTime A_date { get => a_date; set => a_date = value; }
        public string G_name { get => g_name; set => g_name = value; }
        public string U_name { get => u_name; set => u_name = value; }
    }
}
