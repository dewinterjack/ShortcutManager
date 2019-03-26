using System.Diagnostics;

namespace ShortcutManager.Wpf.Utils
{
    internal class ProcessLauncher
    {
        public void Open(string path)
        {
            Process.Start(path);
        }
    }
}
