using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ShortcutManager.WorkspaceStorage;

namespace ShortcutManager.Tests.WorkspaceStorage
{
    internal class WorkspaceStorageServiceShould
    {
        [Test]
        public void SaveWorkspaceWithFormatting()
        {
            var textFileWriter = Substitute.For<ITextWriter>();
            var workspace = new Workspace("MyWorkspace");
            workspace.Shortcuts.Add(new Shortcut("SomeShortcut", "SomeLink"));
            workspace.Shortcuts.Add(new Shortcut("AnotherShortcut", "AnotherLink"));

            var workspaceStorageService = new WorkspaceStorageService(textFileWriter);

            workspaceStorageService.Save(workspace);
            textFileWriter.Received().WriteToStorage(Arg.Is<List<string>>(x =>
                x.Contains("MyWorkspace") && x.Contains("Name: SomeShortcut | Link: SomeLink") &&
                x.Contains("Name: AnotherShortcut | Link: AnotherLink")));
        }
    }
}