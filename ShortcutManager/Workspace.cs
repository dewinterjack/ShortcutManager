using System.Collections.Generic;

namespace ShortcutManager
{
    public class Workspace
    {
        public static Workspace Default = new Workspace();

        public List<Shortcut> Shortcuts { get; }

        public Workspace()
        {
            Shortcuts = new List<Shortcut>();
        }
    }
}
