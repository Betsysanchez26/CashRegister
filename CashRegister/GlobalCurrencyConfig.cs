using Newtonsoft.Json;

namespace CashRegister
{

    public static class GlobalCurrencyConfig
    {
        const string defaultFileToRead = "Settings.json";

        /// <summary>
        /// Add new currency to the Settings.json file. 
        /// </summary>
        /// <param name="currency"></param>
        public static void AddCurrency(string currency)
        {
            Settings setting = new() { Currency = currency };
            string jsonToAdd = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(defaultFileToRead, jsonToAdd);
        }
        /// <summary>
        /// Get currency from the Settings.json file. 
        /// </summary>
        public static string GetCurrency()
        {
            Settings setting = ReadSettingsFile();
            return setting.Currency;
        }
        /// <summary>
        /// Read information from Settings.json file. 
        /// </summary>
        private static Settings ReadSettingsFile()
        {
            try
            {
                string fileContents = File.ReadAllText(defaultFileToRead);
                return JsonConvert.DeserializeObject<Settings>(fileContents);
            }
            catch(FileNotFoundException)
            {
                FileStream fs = File.Create(defaultFileToRead);
                fs.Close();
                return new Settings();
            }
        }
    }
}
    public class Settings
    {
        public string Currency { get; set; }
    }
    