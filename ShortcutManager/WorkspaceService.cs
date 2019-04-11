using ShortcutManager.WorkspaceStorage;

namespace ShortcutManager
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceStorageService _workspaceStorageService;

        public WorkspaceService(IWorkspaceStorageService workspaceStorageService)
        {
            _workspaceStorageService = workspaceStorageService;
        }

        public void AddShortcut(string name, string link)
        {
            var shortcut = new Shortcut(name, link);
            Workspace.Default.Shortcuts.Add(shortcut);
        }

        public void SaveWorkspace()
        {
            _workspaceStorageService.Save(Workspace.Default);
        }
    }
}
