using CSAA.ServiceModels;
using System.Collections.Generic;

namespace Server.Services
{
    public interface IProjectService
    {
        List<Project> GetProjects(string userId);
        Project GetProject(string projectId, string userId);
        string CreateProject(Project project, string userId);
        void UpdateProject(string projectId, Project project);
        void DeleteProject(string projectId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}