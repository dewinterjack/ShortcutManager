namespace ShortcutManager.WorkspaceStorage
{
    public interface IWorkspaceStorageService
    {
        void Save(Workspace workspace);
        Workspace Load();
    }
}