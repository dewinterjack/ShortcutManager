using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var textFileWriter = Substitute.For<IJsonWriter>();
            var workspace = new Workspace("MyWorkspace");
            workspace.Shortcuts.Add(new Shortcut("SomeShortcut", "SomeLink"));
            workspace.Shortcuts.Add(new Shortcut("AnotherShortcut", "AnotherLink"));

            var workspaceStorageService = new WorkspaceStorageService(textFileWriter);

            workspaceStorageService.Save(workspace);
            textFileWriter.Received().WriteToStorage(Arg.Is<IEnumerable<string>>(x =>
                x.SequenceEqual(new[]
                {
                    "MyWorkspace", "Name: SomeShortcut | Link: SomeLink", "Name: AnotherShortcut | Link: AnotherLink"
                })), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }
}