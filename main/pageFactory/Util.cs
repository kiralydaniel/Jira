using NUnit.Framework;

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

        public static IEnumerable<TestCaseData> TestDataSource(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var fields = line.Split(',');
                    var testCaseData = new TestCaseData(fields[0], fields[1]);

                    yield return testCaseData;
                }
            }
        }

        public static IEnumerable<TestCaseData> TestData(string csvFilePath)
        {
            var testData = Util.TestDataSource(csvFilePath);

            foreach (var testCaseData in testData)
            {
                yield return testCaseData;
            }
        }
    }
}