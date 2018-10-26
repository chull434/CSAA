using CSAA.Models;

namespace Client.Requests
{
    interface IProjectRequest
    {
        bool CreateProject(Project project);
    }
}
