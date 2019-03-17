namespace ShortcutManager
{
    internal class ShortcutService
    {
        public void AddShortcut(string name, string link)
        {
            var shortcut = new Shortcut(name, link);
            Workspace.Default.Add(shortcut);
        }
    }
}
