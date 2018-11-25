using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IProjectRequest
    {
        List<Project> GetProjects();
        Project GetProject(string projectId);
        string CreateProject(Project project);
        bool UpdateProject(string projectId, Project project);
        bool DeleteProject(string projectId);
    }
}
