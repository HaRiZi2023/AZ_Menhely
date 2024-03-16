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

        public Worker(int id, string w_name, string w_password, string w_permission)
        {
            this.id = id;
            this.W_name = w_name;
            this.W_password = w_password;
            this.W_permission = w_permission;
        }

        public int Id { get => id; set => id = value; }
        public string W_name { get => w_name; set => w_name = value; }
        public string W_password { get => w_password; set => w_password = value; }
        public string W_permission { get => w_permission; set => w_permission = value; }

        public override string ToString()
        {
            return $"{this.w_name}";
        }
    }
}
