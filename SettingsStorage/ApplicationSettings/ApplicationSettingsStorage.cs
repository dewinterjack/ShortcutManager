using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SettingsStorage.Storage;

namespace SettingsStorage.ApplicationSettings
{
    public class ApplicationSettingsStorage : IApplicationSettingsStorage
    {
        private readonly ISettingsWriter _settingsWriter;
        private readonly ISettingsReader _settingsReader;

        private static string _applicationSettingsFileName = "projectm-appsettings";

        public ApplicationSettingsStorage(ISettingsWriter settingsWriter, ISettingsReader settingsReader)
        {
            _settingsWriter = settingsWriter;
            _settingsReader = settingsReader;
        }

        public IEnumerable<string> LoadLinkedProjects(string applicationSettingsFolderPath)
        {
            return _settingsReader.LoadSettings<IEnumerable<string>>(applicationSettingsFolderPath,
                    _applicationSettingsFileName);
        }

        public void SaveLinkedProject(string applicationSettingsFolderPath, string projectPath)
        {
            var projects = LoadLinkedProjects(applicationSettingsFolderPath);
            projects.Append(projectPath);
            var jsonProjects = JsonConvert.SerializeObject(projects);
            _settingsWriter.WriteToStorage(jsonProjects, applicationSettingsFolderPath, _applicationSettingsFileName);
        }
    }
}
