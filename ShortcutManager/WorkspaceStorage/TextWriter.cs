using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutManager.WorkspaceStorage
{
    public class TextWriter : ITextWriter
    {
        public void WriteToStorage(IEnumerable<string> lines)
        {
            var storageFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DefaultWorkspace.txt");
            File.WriteAllLines(storageFilePath, lines);
        }
    }
}
