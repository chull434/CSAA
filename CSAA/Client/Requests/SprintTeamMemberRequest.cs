using CSAA.ServiceModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSAA.Enums;

namespace Client.Requests
{
    class SprintTeamMemberRequest : Request, ISprintTeamMemberRequest
    {
        #region Constructor

        public SprintTeamMemberRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<SprintTeamMember> GetSprintTeamMembers()
        {
            return GetSprintTeamMembersAsync().GetAwaiter().GetResult();
        }

        public SprintTeamMember GetSprintTeamMember(string sprintTeamMemberId)
        {
            return GetSprintTeamMemberAsync(sprintTeamMemberId).GetAwaiter().GetResult();
        }

        public bool AddSprintTeamMember(SprintTeamMember sprintTeamMember)
        {
            return AddSprintTeamMemberAsync(sprintTeamMember).GetAwaiter().GetResult();
        }

        public bool UpdateSprintTeamMember(string sprintTeamMemberId, SprintTeamMember sprintTeamMember)
        {
            return UpdateSprintTeamMemberAsync(sprintTeamMemberId, sprintTeamMember).GetAwaiter().GetResult();
        }

        public bool DeleteSprintTeamMember(string sprintTeamMemberId)
        {
            return DeleteSprintTeamMemberAsync(sprintTeamMemberId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<SprintTeamMember>> GetSprintTeamMembersAsync()
        {
            var response = await client.GetAsync("api/SprintTeamMember").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<SprintTeamMember>>().ConfigureAwait(false);
        }

        private async Task<SprintTeamMember> GetSprintTeamMemberAsync(string sprintTeamMemberId)
        {
            var response = await client.GetAsync("api/SprintTeamMember/" + sprintTeamMemberId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<SprintTeamMember>().ConfigureAwait(false);
        }

        private async Task<bool> AddSprintTeamMemberAsync(SprintTeamMember sprintTeamMember)
        {
            var response = await client.PostAsJsonAsync("api/SprintTeamMember", sprintTeamMember).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> UpdateSprintTeamMemberAsync(string sprintTeamMemberId, SprintTeamMember sprintTeamMember)
        {
            var response = await client.PutAsJsonAsync("api/SprintTeamMember/" + sprintTeamMemberId, sprintTeamMember).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteSprintTeamMemberAsync(string sprintTeamMemberId)
        {
            var response = await client.DeleteAsync("api/SprintTeamMember/" + sprintTeamMemberId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}
