using System.Windows;
using ShortcutManager.Wpf.WorkspaceHome;

namespace ShortcutManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var workspaceHome = new WorkspaceHomeViewModel();
            DataContext = workspaceHome;
            InitializeComponent();
        }
    }
}
