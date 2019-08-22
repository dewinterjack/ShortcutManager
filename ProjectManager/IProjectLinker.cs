namespace ProjectManager
{
    interface IProjectLinker
    {
        bool IsProjectConfigured(string projectPath);

        void Link(string projectPath);
    }
}
