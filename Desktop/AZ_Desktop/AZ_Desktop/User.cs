using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Desktop
{
    internal class User
    {
        int id;
        string name;
        string email;
        string password;
        string address;
        string phone;

        public User(int id, string name, string email, string password, string address, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Address = address;
            this.Phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }


        public override string ToString()
        {
            return $"{this.id} - {this.name} - {this.email}";
        }
    }
}
