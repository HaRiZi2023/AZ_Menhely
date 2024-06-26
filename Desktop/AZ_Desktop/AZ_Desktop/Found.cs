﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using AZ_Desktop;
//
//    var found = Found.FromJson(jsonString);

namespace AZ_Desktop
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

   

    public partial class Found
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("f_choice")]
        public string F_choice { get; set; }

        [JsonProperty("f_species")]
        public string F_species { get; set; }

        [JsonProperty("f_gender")]
        public string F_gender { get; set; }

        [JsonProperty("f_injury")]
        public string F_injury { get; set; }

        [JsonProperty("f_position")]
        public string F_position { get; set; }

        [JsonProperty("f_other")]
        public string F_other { get; set; }

        [JsonProperty("f_image")]
        public string F_image { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset Created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset Updated_at { get; set; }

        public override string ToString()
        {
            return $"{Id} - {F_choice} - {F_species} - {F_position}";

        }
    }

    public partial class Found
    {
        public static Found[] FromJson(string json) => JsonConvert.DeserializeObject<Found[]>(json, AZ_Desktop.Converter.Settings);
    }
}




/*
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
        byte[] f_image;  
        DateTime created_at;
        DateTime updated_at;

        public Found()
        {
            // Alapértelmezett konstruktor, lehet üres.
        }

        public Found(int id, string f_choice, string f_species, string f_gender, string f_injury, string f_position, string f_other, byte[] f_image, DateTime created_at, DateTime updated_at)
        {
            this.Id = id;
            this.F_choice = f_choice;
            this.F_species = f_species;
            this.F_gender = f_gender;
            this.F_injury = f_injury;
            this.F_position = f_position;
            this.F_other = f_other;
            this.F_image = f_image;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }

        public int Id { get => id; set => id = value; }
        public string F_choice { get => f_choice; set => f_choice = value; }
        public string F_species { get => f_species; set => f_species = value; }
        public string F_gender { get => f_gender; set => f_gender = value; }
        public string F_injury { get => f_injury; set => f_injury = value; }
        public string F_position { get => f_position; set => f_position = value; }
        public string F_other { get => f_other; set => f_other = value; }
        public byte[] F_image { get => f_image; set => f_image = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public override string ToString()
        {
            return $"{this.Id} - {this.F_choice} - {this.F_species} - {this.F_position}";
        }

       

    }
}
*/