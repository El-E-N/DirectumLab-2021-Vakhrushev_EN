using System.Collections.Generic;
using System.Configuration;

namespace Task_12
{
    /// <summary>
    /// Чтения файла .config.
    /// </summary>
    public class ConfigReader
    {
        /// <summary>
        /// Из файла .config получение пар ключ-значение.
        /// </summary>
        /// <returns>Список из пар ключ-значение.</returns>
        public static List<Dictionary<string, string>> GetPairs()
        {
            var listOfConfigPair = new List<Dictionary<string, string>> { };
            var settingsAll = ConfigurationManager.AppSettings;
            foreach (string s in settingsAll.AllKeys)
                listOfConfigPair.Add(new Dictionary<string, string> 
                { 
                    { "Key", s }, 
                    { "Value", settingsAll.Get(s) } 
                });
            return listOfConfigPair;
        }
    }
}
