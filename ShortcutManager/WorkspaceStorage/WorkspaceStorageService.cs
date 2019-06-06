using System.Collections.Generic;
using System.Linq;

namespace ShortcutManager.WorkspaceStorage
{
    public class WorkspaceStorageService : IWorkspaceStorageService
    {
        private readonly ITextWriter _textWriter;

        public WorkspaceStorageService(ITextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void Save(Workspace workspace)
        {
            var formattedWorkspace = FormatWorkspace(workspace);
            _textWriter.WriteToStorage(formattedWorkspace);
        }

        private static IEnumerable<string> FormatWorkspace(Workspace workspace)
        {
            var workspaceContents = new List<string> {workspace.Name};
            var workspaceShortcuts = workspace.Shortcuts.Select(shortcut => $"Name: {shortcut.Name} | Link: {shortcut.Link}");
            workspaceContents.AddRange(workspaceShortcuts);
            return workspaceContents;
        }
    }
}
