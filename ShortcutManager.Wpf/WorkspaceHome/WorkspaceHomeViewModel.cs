using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ShortcutManager.Annotations;
using ShortcutManager.WorkspaceStorage;
using ShortcutManager.Wpf.Utils;
using TextWriter = ShortcutManager.WorkspaceStorage.TextWriter;

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

        public ICommand Save =>
            new RelayCommand(_ => SaveAll());

        public ICommand LaunchShortcut => new RelayCommand(ExecuteLink);

        private void ExecuteLink(object selectedShortcut)
        {
            if (selectedShortcut is string shortcutLink) Process.Start(shortcutLink);
        }

        public ObservableCollection<Shortcut> DefaultWorkspace { get; }

        public WorkspaceHomeViewModel()
        {
            var textWriter = new TextWriter();
            var workspaceStorageService = new WorkspaceStorageService(textWriter);
            _workspaceService = new WorkspaceService(workspaceStorageService);
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

        private void SaveAll()
        {
            _workspaceService.SaveWorkspace();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
