using System.Collections.Generic;

namespace ShortcutManager.WorkspaceStorage
{
    public interface ITextWriter
    {
        void WriteToStorage(List<string> lines);
    }
}