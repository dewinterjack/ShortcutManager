using System.Collections.Generic;

namespace ShortcutManager.WorkspaceStorage
{
    public interface ITextWriter
    {
        void WriteToStorage(string text);
    }
}