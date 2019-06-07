using System.IO;

namespace ShortcutManager.WorkspaceStorage
{
    public class JsonWriter : IJsonWriter
    {
        public void WriteToStorage(string text, string path)
        {
            var storageFilePath = Path.Combine(path, "Workspaces.json");
            File.WriteAllText(storageFilePath, text);
        }
    }
}
