using System.Threading.Tasks;
using CSAA.DataModels;

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

        #endregion

        #region Private Methods

        private async Task<bool> CreateProjectAsync(Project project)
        {
            var response = await client.PostAsJsonAsync("api/Project", project).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }

        #endregion
    }
}
