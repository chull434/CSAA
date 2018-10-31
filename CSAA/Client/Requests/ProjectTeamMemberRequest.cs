using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAA.ServiceModels;

namespace Client.Requests
{

    public class ProjectTeamMemberRequest : Request, IProjectTeamMemberRequest
    {
        public ProjectTeamMemberRequest(IHttpClient client) : base(client)
        {

        }

        public bool AddTeamMember(string email, string projectId)
        {
            return AddTeamMemberAsync(email, projectId).GetAwaiter().GetResult();
        }

        private async Task<bool> AddTeamMemberAsync(string email, string projectId)
        {
            var response = await client.PostAsJsonAsync("api/ProjectTeamMember", new AddTeamMember{email = email, projectId = projectId}).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }
    }
}
