using CSAA.DataModels;

namespace Client.Requests
{
    interface IProjectRequest
    {
        bool CreateProject(Project project);

        Project GetProjectById(string projectId);
    }
}
