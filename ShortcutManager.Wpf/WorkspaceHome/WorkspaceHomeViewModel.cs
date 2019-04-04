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

        public ObservableCollection<string> DefaultWorkspaceNames { get; }

        public WorkspaceHomeViewModel()
        {
            _workspaceService = new WorkspaceService();
            DefaultWorkspaceNames = new ObservableCollection<string>();
        }

        private void AddShortcut()
        {
            _workspaceService.AddShortcut("Hello", "world");
            var shortcutName = Workspace.Default.Shortcuts.Last().Name;
            DefaultWorkspaceNames.Add(shortcutName);
        }

    }
}
