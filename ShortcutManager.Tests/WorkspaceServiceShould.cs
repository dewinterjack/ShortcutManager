using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ShortcutManager.WorkspaceStorage;
using Shouldly;

namespace ShortcutManager.Tests
{
    public class WorkspaceServiceShould
    {
        private IWorkspaceStorageService _workspaceStorageService;
        private WorkspaceService _workspaceService;

        [SetUp]
        public void SetUp()
        {
            _workspaceStorageService = Substitute.For<IWorkspaceStorageService>();
            _workspaceService = new WorkspaceService(_workspaceStorageService);
        }

        [Test]
        public void AddShortcutToDefaultWorkspace()
        {
            Workspace.Default.Shortcuts.ShouldBeEmpty();

            var shortcutName = "Github Profile";
            var shortcutLink = "https://github.com/dewinterjack";
            _workspaceService.AddShortcut(shortcutName, shortcutLink);

            Workspace.Default.Shortcuts.Count.ShouldBe(1);
            Workspace.Default.Shortcuts.First().Name.ShouldBe(shortcutName);
            Workspace.Default.Shortcuts.First().Link.ShouldBe(shortcutLink);
        }

        [Test]
        public void SaveDefaultWorkspaceToStorage()
        {
            var shortcutName = "Github Profile";
            var shortcutLink = "https://github.com/dewinterjack";
            _workspaceService.AddShortcut(shortcutName, shortcutLink);

            _workspaceService.SaveWorkspace();
            
            _workspaceStorageService.Received().Save(Workspace.Default);
        }
    }
}
