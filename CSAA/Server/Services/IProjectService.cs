using CSAA.ServiceModels;
using System.Collections.Generic;

namespace Server.Services
{
    public interface IProjectService
    {
        List<Project> GetProjects(IApplicationUserManager UserManager);
        Project GetProject(string projectId, string userId, IApplicationUserManager UserManager);
        string CreateProject(Project project, string userId);
        void UpdateProject(string projectId, Project project);
        void DeleteProject(string projectId);
    }
}