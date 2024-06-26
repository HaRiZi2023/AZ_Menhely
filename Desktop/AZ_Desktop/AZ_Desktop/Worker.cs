﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using AZ_Desktop;
//
//    var worker = Worker.FromJson(jsonString);

namespace AZ_Desktop
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

   

    /***/

    public static class Serialize
    {
        public static string ToJson(this Worker[] self) => JsonConvert.SerializeObject(self, AZ_Desktop.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    /***/

    public partial class Worker
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("w_name")]
        public string W_name { get; set; }

        [JsonProperty("w_password")]
        public string W_password { get; set; }

        [JsonProperty("w_permission")]
        public string W_permission { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset Created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset Update_at { get; set; }

        [JsonProperty("deleted_at")]
        public object Deleted_at { get; set; }

        public override string ToString()
        {
            return W_name;
        }

    }

    public enum W_permission { teljes, felhasználó };

    public partial class Worker
    {
        public static Worker[] FromJson(string json) => JsonConvert.DeserializeObject<Worker[]>(json, AZ_Desktop.Converter.Settings);
    }

  

    /***/

    internal class W_permissionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(W_permission) || t == typeof(W_permission?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "teljes":
                    return W_permission.teljes;
                case "felhasználó":
                    return W_permission.felhasználó;
            }
            throw new Exception("Cannot unmarshal type Gender");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (W_permission)untypedValue;
            switch (value)
            {
                case W_permission.teljes:
                    serializer.Serialize(writer, "teljes");
                    return;
                case W_permission.felhasználó:
                    serializer.Serialize(writer, "felhasználó");
                    return;
            }
            throw new Exception("Cannot marshal type Gender");
        }

        public static readonly W_permissionConverter Singleton = new W_permissionConverter();
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
*/