using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Desktop
{
    public class Guest
    {
        int id;
        string g_name;
        string g_chip;
        string g_species;
        string g_gender;  
        DateTime g_in_date;    
        string g_in_place;
        DateTime g_out_date;    
        string g_adoption; 
        string g_other;
        byte [] g_image;
        DateTime created_at;
        DateTime updated_at;


        public Guest()
        {
            this.Created_at = DateTime.Now; // Az objektum létrehozásának időpontja
            this.Updated_at = DateTime.Now; // Az utolsó frissítés időpontja
        }

        public Guest(int id, string g_name, string g_chip, string g_species, string g_gender, DateTime g_in_date, string g_in_place, DateTime g_out_date, string g_adoption, string g_other, byte[] g_image, DateTime created_at, DateTime updated_at)
        {
            this.Id = id;
            this.G_name = g_name;
            this.G_chip = g_chip;
            this.G_species = g_species;
            this.G_gender = g_gender;
            this.G_in_date = g_in_date;
            this.G_in_place = g_in_place;
            this.G_out_date = g_out_date;
            this.G_adoption = g_adoption;
            this.G_other = g_other;
            this.G_image = g_image;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }

        public int Id { get => id; set => id = value; }
        public string G_name { get => g_name; set => g_name = value; }
        public string G_chip { get => g_chip; set => g_chip = value; }
        public string G_species { get => g_species; set => g_species = value; }
        public string G_gender { get => g_gender; set => g_gender = value; }
        public DateTime G_in_date { get => g_in_date; set => g_in_date = value; }
        public string G_in_place { get => g_in_place; set => g_in_place = value; }
        public DateTime G_out_date { get => g_out_date; set => g_out_date = value; }
        public string G_adoption { get => g_adoption; set => g_adoption = value; }
        public string G_other { get => g_other; set => g_other = value; }
        public byte[] G_image { get; set; }//{ get => g_image; set => g_image = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public override string ToString()
        {
            string species = string.IsNullOrEmpty(this.G_species) ? "Nincs? Probléma a fajtával" : this.G_species;
            string name = string.IsNullOrEmpty(this.G_name) ? "Nincs? Probléma a névvel!" : this.G_name;
            return $"{this.G_species} - {this.G_name}";
        }


    }
}
