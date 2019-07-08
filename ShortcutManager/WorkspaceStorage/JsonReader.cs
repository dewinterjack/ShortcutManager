﻿using System.IO;
using Newtonsoft.Json;

namespace ShortcutManager.WorkspaceStorage
{
    public class JsonReader : IJsonReader
    {
        public T LoadJson<T>(string path) where T : class
        {
            path = Path.Combine(path, "Workspaces.json");
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var fileText = File.ReadAllText(path);

            if (fileText.Length == 0)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(fileText);
        }
    }
}
