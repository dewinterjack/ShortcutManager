namespace ShortcutManager.WorkspaceStorage
{
    public interface IJsonReader
    {
        T LoadJson<T>(string path) where T : class;
    }
}
