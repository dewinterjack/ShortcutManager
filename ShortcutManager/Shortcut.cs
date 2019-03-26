namespace ShortcutManager
{
    public class Shortcut
    {
        public string Name { get; }
        public string Link { get; }

        public Shortcut(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}