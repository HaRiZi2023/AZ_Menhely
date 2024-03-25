using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Desktop
{
    internal class Found
    {
        int id;
        string f_choice;  
        string f_species; 
        string f_gender;  
        string f_injury;
        string f_position;
        string f_other;
        string f_image;

        public Found(int id, string f_choice, string f_species, string f_gender, string f_injury, string f_position, string f_other, string f_image)
        {
            this.Id = id;
            this.F_choice = f_choice;
            this.F_species = f_species;
            this.F_gender = f_gender;
            this.F_injury = f_injury;
            this.F_position = f_position;
            this.F_other = f_other;
            this.F_image = f_image;
        }

        public int Id { get => id; set => id = value; }
        public string F_choice { get => f_choice; set => f_choice = value; }
        public string F_species { get => f_species; set => f_species = value; }
        public string F_gender { get => f_gender; set => f_gender = value; }
        public string F_injury { get => f_injury; set => f_injury = value; }
        public string F_position { get => f_position; set => f_position = value; }
        public string F_other { get => f_other; set => f_other = value; }
        public string F_image { get => f_image; set => f_image = value; }

        public override string ToString()
        {
            return $"{this.id} - {this.f_choice} - {this.f_species} - {this.f_position}";
        }

        public Found()
        {
            // Alapértelmezett konstruktor, lehet üres.
        }
    }
}
