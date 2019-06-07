using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShortcutManager.Bindings
{
    public sealed class WorkspaceJsonBinding
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<Shortcut> Shortcuts { get; }
    }
}
