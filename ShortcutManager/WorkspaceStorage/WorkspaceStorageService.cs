using System;
using System.Linq;
using Newtonsoft.Json;

namespace ShortcutManager.WorkspaceStorage
{
    public class WorkspaceStorageService : IWorkspaceStorageService
    {
        private readonly IJsonWriter _jsonWriter;
        private readonly IJsonReader _jsonReader;
        private readonly string _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public WorkspaceStorageService(IJsonWriter jsonWriter, IJsonReader jsonReader)
        {
            _jsonWriter = jsonWriter;
            _jsonReader = jsonReader;
        }

        public void Save(Workspace workspace)
        {
            var jsonWorkspace = JsonConvert.SerializeObject(workspace, Formatting.Indented);
            _jsonWriter.WriteToStorage(jsonWorkspace, _appDataPath);
        }

        public Workspace Load()
        {
            var workspaces = _jsonReader.LoadJson<Workspace[]>(_appDataPath);
            if (workspaces == null)
            {
                return new Workspace("Default");
            }
            return workspaces.FirstOrDefault(x => x.Name == "Default");
        }
    }
}
