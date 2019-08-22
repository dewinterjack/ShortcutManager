using System.IO;
using System.Linq;
using SettingsStorage.ApplicationSettings;

namespace ProjectManager
{
    internal class ProjectLinker : IProjectLinker
    {
        private readonly IApplicationSettingsStorage _applicationSettingsStorage;
        private readonly string _applicationSettingsFilePath;

        public ProjectLinker(IApplicationSettingsStorage applicationSettingsStorage, string applicationSettingsFilePath)
        {
            _applicationSettingsStorage = applicationSettingsStorage;
            _applicationSettingsFilePath = applicationSettingsFilePath;
        }

        public bool IsProjectConfigured(string projectPath)
        {
            return File.Exists(Path.Combine(projectPath, ".projectm"));
        }

        public bool IsProjectLinked(string projectPath)
        {
            var projects = _applicationSettingsStorage.LoadLinkedProjects(_applicationSettingsFilePath);
            return projects.Contains(projectPath);
        }

        public void Link(string projectPath)
        {
            if (IsProjectLinked(projectPath))
            {
                return;
            }

            _applicationSettingsStorage.SaveLinkedProject(_applicationSettingsFilePath, projectPath);
        }
    }
}
