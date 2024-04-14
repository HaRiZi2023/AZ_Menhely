using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Windows.Forms;

namespace AZ_Desktop
{
    public static class Helpers   //internal class
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string endPoint = ReadSetting("endpointUrl");

        private static string ReadSetting(string keyName)
        {
            string result = null;
            try
            {
                var value = ConfigurationManager.AppSettings;
                result = value[keyName];
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static HttpClient GetHttpClient()
        {
            return client;
        }

        public static string GetEndPoint()
        {
            return endPoint;
        }
    



        // ezeket az osztályokhoz használom a,f,g,u,w

        public static string ToJson<T>(this T[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
        
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
        /*
        public static HttpClient client = new HttpClient();
        public static string endPoint = ReadSetting("endPointUrl");

        private static string ReadSetting(string keyName)  // kiszerv
        {
            string result = null;
            try
            {
                var value = ConfigurationManager.AppSettings;
                result = value[keyName];
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        */

    }
}
 