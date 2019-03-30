using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace ShortcutManager.Tests
{
    public class ShortcutServiceShould
    {
        [Test]
        public void AddShortcutToDefaultWorkspace()
        {
            var workspaceService = new WorkspaceService();
            Workspace.Default.ShouldBeEmpty();

            var shortcutName = "Github Profile";
            var shortcutLink = "https://github.com/dewinterjack";
            workspaceService.AddShortcut(shortcutName, shortcutLink);

            Workspace.Default.Count.ShouldBe(1);
            Workspace.Default.First().Name.ShouldBe(shortcutName);
            Workspace.Default.First().Link.ShouldBe(shortcutLink);
        }
    }
}
