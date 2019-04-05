using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ShortcutManager.Annotations;
using ShortcutManager.Wpf.Utils;

namespace ShortcutManager.Wpf.WorkspaceHome
{
    public class WorkspaceHomeViewModel : INotifyPropertyChanged
    {
        private readonly IWorkspaceService _workspaceService;
        private string _newShortcutName;
        private string _newShortcutLink;

        public string NewShortcutName
        {
            get => _newShortcutName;
            set
            {
                _newShortcutName = value;
                OnPropertyChanged(nameof(NewShortcutName));
            }
        }

        public string NewShortcutLink
        {
            get => _newShortcutLink;
            set
            {
                _newShortcutLink = value;
                OnPropertyChanged(nameof(NewShortcutLink));
            }
        }

        public ICommand CreateShortcut =>
            new RelayCommand( _ => AddShortcut());

        public ICommand LaunchShortcut => new RelayCommand(selectedShortcut => ExecuteLink((Shortcut) selectedShortcut));

        private void ExecuteLink(Shortcut selectedShortcut)
        {
            Process.Start(selectedShortcut.Link);
        }

        public ObservableCollection<Shortcut> DefaultWorkspace { get; }

        public WorkspaceHomeViewModel()
        {
            _workspaceService = new WorkspaceService();
            DefaultWorkspace = new ObservableCollection<Shortcut>();
        }

        private void AddShortcut()
        {
            _workspaceService.AddShortcut(NewShortcutName, NewShortcutLink);
            var shortcut = Workspace.Default.Shortcuts.Last();
            DefaultWorkspace.Add(shortcut);
            NewShortcutName = "";
            NewShortcutLink = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
