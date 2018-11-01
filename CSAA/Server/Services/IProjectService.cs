using CSAA.Models;

namespace Server.Services
{
    public interface IProjectService
    {
        void CreateProject(Project project, string userId);
    }
}