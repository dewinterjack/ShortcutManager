using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ShortcutManager.WorkspaceStorage
{
    public class WorkspaceStorageService : IWorkspaceStorageService
    {
        private readonly ITextWriter _textWriter;

        public WorkspaceStorageService(ITextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void Save(Workspace workspace)
        {
            var jsonWorkspace = JsonConvert.SerializeObject(workspace);
            _textWriter.WriteToStorage(jsonWorkspace);
        }
    }
}
