using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ShortcutManager.WorkspaceStorage
{
    public class WorkspaceStorageService : IWorkspaceStorageService
    {
        private readonly IJsonWriter _jsonWriter;
        private readonly IJsonReader _jsonReader;
        private readonly string _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private List<Workspace> _workspaces;

        public WorkspaceStorageService(IJsonWriter jsonWriter, IJsonReader jsonReader)
        {
            _jsonWriter = jsonWriter;
            _jsonReader = jsonReader;
            _workspaces = new List<Workspace>();
        }

        public void Save(Workspace workspace)
        {
            _workspaces.Add(workspace);
            var jsonWorkspaces = JsonConvert.SerializeObject(_workspaces, Formatting.Indented);
            _jsonWriter.WriteToStorage(jsonWorkspaces, _appDataPath);
        }

        public Workspace Load()
        {
            _workspaces = _jsonReader.LoadJson<Workspace[]>(_appDataPath).ToList();
            if (_workspaces.Count == 0 || _workspaces == null)
            {
                return new Workspace("Default");
            }
            return _workspaces.FirstOrDefault(x => x.Name == "Default");
        }
    }
}
