namespace SettingsStorage.Storage
{
    public interface ISettingsWriter
    {
        void WriteToStorage(string text, string folderPath, string settingsFileName);
    }
}