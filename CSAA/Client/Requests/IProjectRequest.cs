using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    interface IProjectRequest
    {
        List<Project> GetProjects();
        Project GetProjectById(string projectId);
        string CreateProject(Project project);
        bool UpdateProject(string projectId, Project project);
        bool DeleteProject(string projectId);
    }
}
