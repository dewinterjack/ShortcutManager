using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using ShortcutManager.Wpf.Utils;

namespace ShortcutManager.Wpf.WorkspaceHome
{
    public class WorkspaceHomeViewModel
    {
        private readonly IShortcutService _shortcutService;
        public ICommand CreateShortcut => new RelayCommand(_ => _shortcutService.AddShortcut("Hello", "world"), _ => true);

        public WorkspaceHomeViewModel()
        {
            _shortcutService = new ShortcutService();
        }

    }
}
