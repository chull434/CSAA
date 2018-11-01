using CSAA.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace Client.Requests
{
    public class ProjectRequest : Request, IProjectRequest
    {
        #region Constructor

        public ProjectRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public bool CreateProject(Project project)
        {
            return CreateProjectAsync(project).GetAwaiter().GetResult();
        }

        public Project GetProjectById(string projectId)
        {
            return GetProjectByIdAsync(projectId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<bool> CreateProjectAsync(Project project)
        {
            var response = await client.PostAsJsonAsync("api/Project", project).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }
        private async Task<Project> GetProjectByIdAsync(string projectId)
        {
            var response = await client.GetAsync("api/Project/" + projectId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var project = await response.Content.ReadAsAsync<Project>().ConfigureAwait(false);

            return project;
        }

        #endregion
    }
}
