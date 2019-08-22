using System.IO;
using Newtonsoft.Json;

namespace SettingsStorage.Storage
{
    public class JsonSettingsReader : ISettingsReader
    {
        public T LoadSettings<T>(string folderPath, string settingsFileName) where T : class
        {
            folderPath = Path.Combine(folderPath, settingsFileName + ".json");
            if (!File.Exists(folderPath))
            {
                File.Create(folderPath);
            }

            var fileText = File.ReadAllText(folderPath);
            return JsonConvert.DeserializeObject<T>(fileText);
        }
    }
}
