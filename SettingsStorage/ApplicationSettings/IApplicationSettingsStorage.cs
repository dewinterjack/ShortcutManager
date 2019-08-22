using System.Collections.Generic;

namespace SettingsStorage.ApplicationSettings
{
    public interface IApplicationSettingsStorage
    {
        IEnumerable<string> LoadLinkedProjects(string applicationSettingsFolderPath);

        void SaveLinkedProject(string applicationSettingsFolderPath, string projectPath);
    }
}