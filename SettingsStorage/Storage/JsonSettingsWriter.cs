using System.IO;

namespace SettingsStorage.Storage
{
    public class JsonSettingsWriter : ISettingsWriter
    {
        public void WriteToStorage(string text, string folderPath, string settingsFileName)
        {
            var storageFilePath = Path.Combine(folderPath, settingsFileName + ".json");
            File.WriteAllText(storageFilePath, text);
        }
    }
}
