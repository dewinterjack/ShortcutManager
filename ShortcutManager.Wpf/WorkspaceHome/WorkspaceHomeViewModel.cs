using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using ShortcutManager.Wpf.Utils;

namespace ShortcutManager.Wpf.WorkspaceHome
{
    public class WorkspaceHomeViewModel
    {
        private readonly IShortcutService _shortcutService;

        public ICommand CreateShortcut =>
            new RelayCommand( _ => AddShortcut(), _ => true);

        public ObservableCollection<string> DefaultWorkspaceNames { get; }

        public WorkspaceHomeViewModel()
        {
            _shortcutService = new ShortcutService();
            DefaultWorkspaceNames = new ObservableCollection<string>();
        }

        public void LaunchShortcut(Shortcut shortcut)
        {
            var processLauncher = new ProcessLauncher();
            processLauncher.Open(shortcut.Link);
        }

        private void AddShortcut()
        {
            _shortcutService.AddShortcut("Hello", "world");
            var shortcutName = Workspace.Default.Last().Name;
            DefaultWorkspaceNames.Add(shortcutName);
        }

    }
}
