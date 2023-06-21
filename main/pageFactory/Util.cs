using System.Collections.Generic;
using System.IO;

namespace Jira.main.pageFactory
{
    public class Util
    {
        private static string initPropertiesFilePath = "main/resources/init.properties";
        private static Dictionary<string, string> initProperties;
        public static string username;
        public static string password;
        public static string baseURL;

        static Util()
        {
            initProperties = ReadInitPropertiesFile(initPropertiesFilePath);
            username = GetPropertyValue("username");
            password = GetPropertyValue("password");
            baseURL = GetPropertyValue("baseURL");
        }

        public static Dictionary<string, string> ReadInitPropertiesFile(string filePath)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        string[] keyValue = line.Split('=');
                        if (keyValue.Length == 2)
                        {
                            string key = keyValue[0].Trim();
                            string value = keyValue[1].Trim();
                            properties[key] = value;
                        }
                    }
                }
            }

            return properties;
        }

        public static string GetPropertyValue(string key)
        {
            if (initProperties.ContainsKey(key))
            {
                return initProperties[key];
            }

            return null;
        }
    }
}