using CSAA.DataModels;

namespace Server.Services
{
    public interface IProjectService
    {
        void CreateProject(Project project, string userId);
        Project GetProject(string projectId);
    }
}