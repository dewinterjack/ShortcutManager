using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ShortcutManager.Wpf.Utils;

namespace ShortcutManager.Wpf.WorkspaceHome
{
    public class WorkspaceHomeViewModel
    {
        private readonly IWorkspaceService _workspaceService;

        public ICommand CreateShortcut =>
            new RelayCommand( _ => AddShortcut(), _ => true);

        public ObservableCollection<Shortcut> DefaultWorkspace { get; }

        public WorkspaceHomeViewModel()
        {
            _workspaceService = new WorkspaceService();
            DefaultWorkspace = new ObservableCollection<Shortcut>();
        }

        private void AddShortcut()
        {
            _workspaceService.AddShortcut("Hello", "world");
            var shortcut = Workspace.Default.Shortcuts.Last();
            DefaultWorkspace.Add(shortcut);
        }

    }
}
