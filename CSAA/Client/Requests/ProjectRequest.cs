using CSAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Requests
{
    class ProjectRequest : Request
    {
        public ProjectRequest() : base()
        {

        }

        public ProjectRequest(IHttpClient client) : base(client)
        {

        }

        public bool CreateProject(Project project)
        {
            return CreateProjectAsync(project).GetAwaiter().GetResult();
        }

        private async Task<bool> CreateProjectAsync(Project project)
        {
            var response = await client.PostAsJsonAsync("api/Project", project).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}
