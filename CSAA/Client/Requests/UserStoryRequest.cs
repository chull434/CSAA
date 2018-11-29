using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public class UserStoryRequest : Request, IUserStoryRequest
    {
        #region Constructor

        public UserStoryRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<UserStory> GetUserStories()
        {
            return GetUserStoriesAsync().GetAwaiter().GetResult();
        }

        public UserStory GetUserStoryById(string userStoryId)
        {
            return GetUserStoryByIdAsync(userStoryId).GetAwaiter().GetResult();
        }

        public string CreateUserStory(UserStory userStory)
        {
            return CreateUserStoryAsync(userStory).GetAwaiter().GetResult();
        }

        public bool UpdateUserStory(string userStoryId, UserStory userStory)
        {
            return UpdateUserStoryAsync(userStoryId, userStory).GetAwaiter().GetResult();
        }

        public bool DeleteUserStory(string userStoryId)
        {
            return DeleteUserStoryAsync(userStoryId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<UserStory>> GetUserStoriesAsync()
        {
            var response = await client.GetAsync("api/UserStory").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<UserStory>>().ConfigureAwait(false);
        }

        private async Task<UserStory> GetUserStoryByIdAsync(string userStoryId)
        {
            var response = await client.GetAsync("api/UserStory/" + userStoryId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<UserStory>().ConfigureAwait(false);
        }

        private async Task<string> CreateUserStoryAsync(UserStory userStory)
        {
            var response = await client.PostAsJsonAsync("api/UserStory", userStory).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var userStoryId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return userStoryId.Substring(1, userStoryId.Length - 2);
        }

        private async Task<bool> UpdateUserStoryAsync(string userStoryId, UserStory userStory)
        {
            var response = await client.PutAsJsonAsync("api/UserStory/" + userStoryId, userStory).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteUserStoryAsync(string userStoryId)
        {
            var response = await client.DeleteAsync("api/UserStory/" + userStoryId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}
