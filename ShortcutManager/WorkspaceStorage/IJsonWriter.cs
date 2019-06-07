using System.Collections.Generic;

namespace ShortcutManager.WorkspaceStorage
{
    public interface IJsonWriter
    {
        void WriteToStorage(string text, string path);
    }
}