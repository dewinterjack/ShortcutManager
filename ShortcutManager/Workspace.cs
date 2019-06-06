using System;
using System.Collections.Generic;

namespace ShortcutManager
{
    [Serializable]
    public class Workspace
    {
        public string Name { get; }
        public static Workspace Default = new Workspace("Default");

        public List<Shortcut> Shortcuts { get; }

        public Workspace(string name)
        {
            Name = name;
            Shortcuts = new List<Shortcut>();
        }
    }
}
