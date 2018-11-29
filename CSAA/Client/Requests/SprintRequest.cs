using System.Collections.Generic;
using System.Threading.Tasks;
using CSAA.ServiceModels;
using System.Net.Http;
namespace Client.Requests
{
    public class SprintRequest : Request, ISprintRequest
    {
        #region Constructor

        public SprintRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<Sprint> GetSprints()
        {
            return GetSprintsAsync().GetAwaiter().GetResult();
        }

        public Sprint GetSprint(string sprintId)
        {
            return GetSprintAsync(sprintId).GetAwaiter().GetResult();
        }

        public string CreateSprint(Sprint sprint)
        {
            return CreateSprintAsync(sprint).GetAwaiter().GetResult();
        }

        public bool UpdateSprint(string sprintId, Sprint sprint)
        {
            return UpdateSprintAsync(sprintId, sprint).GetAwaiter().GetResult();
        }

        public bool DeleteSprint(string sprintId)
        {
            return DeleteSprintAsync(sprintId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<Sprint>> GetSprintsAsync()
        {
            var response = await client.GetAsync("api/Sprint").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<Sprint>>().ConfigureAwait(false);
        }

        private async Task<Sprint> GetSprintAsync(string sprintId)
        {
            var response = await client.GetAsync("api/Sprint/" + sprintId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<Sprint>().ConfigureAwait(false);
        }

        private async Task<string> CreateSprintAsync(Sprint sprint)
        {
            var response = await client.PostAsJsonAsync("api/Sprint", sprint).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var sprintId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return sprintId.Substring(1, sprintId.Length - 2);
        }

        private async Task<bool> UpdateSprintAsync(string sprintId, Sprint sprint)
        {
            var response = await client.PutAsJsonAsync("api/Sprint/" + sprintId, sprint).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteSprintAsync(string sprintId)
        {
            var response = await client.DeleteAsync("api/Sprint/" + sprintId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}
