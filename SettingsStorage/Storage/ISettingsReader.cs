namespace SettingsStorage.Storage
{
    public interface ISettingsReader
    {
        T LoadSettings<T>(string folderPath, string settingsFileName) where T : class;
    }
}
