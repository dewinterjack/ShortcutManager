using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace ShortcutManager.Tests
{
    public class WorkspaceServiceShould
    {
        [Test]
        public void AddShortcutToDefaultWorkspace()
        {
            var workspaceService = new WorkspaceService();
            Workspace.Default.Shortcuts.ShouldBeEmpty();

            var shortcutName = "Github Profile";
            var shortcutLink = "https://github.com/dewinterjack";
            workspaceService.AddShortcut(shortcutName, shortcutLink);

            Workspace.Default.Shortcuts.Count.ShouldBe(1);
            Workspace.Default.Shortcuts.First().Name.ShouldBe(shortcutName);
            Workspace.Default.Shortcuts.First().Link.ShouldBe(shortcutLink);
        }
    }
}
