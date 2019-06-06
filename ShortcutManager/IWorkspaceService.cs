namespace ShortcutManager
{
    public interface IWorkspaceService
    {
        void AddShortcut(string name, string link);

        void SaveWorkspace();
    }
}
