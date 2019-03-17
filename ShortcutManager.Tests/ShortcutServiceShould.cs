using NUnit.Framework;

namespace ShortcutManager.Tests
{
    public class ShortcutServiceShould
    {
        [Test]
        public void AddShortcutToDefaultWorkspace()
        {
            var shortcutService = new ShortcutService();
            Workspace.Default.ShouldBeEmpty();

            var shortcutName = "Github Profile";
            var shortcutLink = "https://github.com/dewinterjack";
            shortcutService.AddShortcut(shortcutName, shortcutLink);

            Workspace.Default.Count.ShouldBe(1);
            Workspace.Default.First().Name.ShouldBe(shortcutName);
            Workspace.Default.First().Link.ShouldBe(shortcutLink);
        }
    }
}
