using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using TryCatch.Resources.Util;

namespace TryCatch.Web.Shop
{
    public class JsResourcesGenerator
    {
        private string _filePath;

        public JsResourcesGenerator(string filePath)
        {
            _filePath = filePath;
        }

        public void GenerateJsResourcesFile()
        {
            string script = string.Format("var Resources = {0};", GetResourcesJson());
            File.WriteAllText(_filePath, script);
        }

        public static string GetResourcesJson()
        {
            var resources = new Dictionary<string, object>();

            (TypeExport.GetAllResxTypes() as List<Type>).ForEach(type =>
            {
                var texts = ResourceToDictionary(type, CultureInfo.CurrentCulture);
                resources.Add(type.Name, texts);
            });

            return JsonConvert.SerializeObject(resources, Formatting.Indented, 
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        private static Dictionary<string, string> ResourceToDictionary(Type resource, CultureInfo culture)
        {
            ResourceManager rm = new ResourceManager(resource);
            PropertyInfo[] pis = resource.GetProperties(BindingFlags.Public | BindingFlags.Static);
            IEnumerable<KeyValuePair<string, string>> values =
                from pi in pis
                where pi.PropertyType == typeof(string)
                select new KeyValuePair<string, string>(
                    pi.Name,
                    rm.GetString(pi.Name, culture));
            Dictionary<string, string> dictionary = values.ToDictionary(k => k.Key, v => v.Value);

            return dictionary;
        }
    }
}