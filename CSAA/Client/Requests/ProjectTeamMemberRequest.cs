using CSAA.ServiceModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Requests
{
    /// <summary>
    /// Constructs the Project Team Member request. Add, update and delete Project Team Members included using projectTeamMember ID.
    /// Calling Asynchronously so as not to block the UI. 
    /// </summary>
    public class ProjectTeamMemberRequest : Request, IProjectTeamMemberRequest
    {
        #region Constructor

        public ProjectTeamMemberRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Method gets a list of all team members.
        /// </summary>
        /// <returns></returns>
        /// List of Project Team Members.
        public List<ProjectTeamMember> GetProjectTeamMembers()
        {
            return GetProjectTeamMembersAsync().GetAwaiter().GetResult();
        }

        public ProjectTeamMember GetProjectTeamMember(string projectTeamMemberId)
        {
            return GetProjectTeamMemberAsync(projectTeamMemberId).GetAwaiter().GetResult();
        }

        public bool AddProjectTeamMember(string email, string projectId)
        {
            return AddProjectTeamMemberAsync(email, projectId).GetAwaiter().GetResult();
        }

        public bool UpdateProjectTeamMember(string projectTeamMemberId, ProjectTeamMember projectTeamMember)
        {
            return UpdateProjectTeamMemberAsync(projectTeamMemberId, projectTeamMember).GetAwaiter().GetResult();
        }

        public bool DeleteProjectTeamMember(string projectTeamMemberId)
        {
            return DeleteProjectTeamMemberAsync(projectTeamMemberId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<ProjectTeamMember>> GetProjectTeamMembersAsync()
        {
            var response = await client.GetAsync("api/ProjectTeamMember").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<ProjectTeamMember>>().ConfigureAwait(false);
        }

        private async Task<ProjectTeamMember> GetProjectTeamMemberAsync(string projectTeamMemberId)
        {
            var response = await client.GetAsync("api/ProjectTeamMember/" + projectTeamMemberId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<ProjectTeamMember>().ConfigureAwait(false);
        }

        private async Task<bool> AddProjectTeamMemberAsync(string email, string projectId)
        {
            var response = await client.PostAsJsonAsync("api/ProjectTeamMember", new ProjectTeamMember{ UserEmail = email, ProjectId = projectId}).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> UpdateProjectTeamMemberAsync(string projectTeamMemberId, ProjectTeamMember projectTeamMember)
        {
            var response = await client.PutAsJsonAsync("api/ProjectTeamMember/" + projectTeamMemberId, projectTeamMember).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteProjectTeamMemberAsync(string projectTeamMemberId)
        {
            var response = await client.DeleteAsync("api/ProjectTeamMember/"+ projectTeamMemberId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}
