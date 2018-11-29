using System.Collections.Generic;
using System.Threading.Tasks;
using CSAA.ServiceModels;
using System.Net.Http;

namespace Client.Requests
{
    class UserRequest : Request, IUserRequest
    {
        #region Constructor

        public UserRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<User> GetUsers()
        {
            return GetUsersAsync().GetAwaiter().GetResult();
        }

        public User GetUser(string userId)
        {
            return GetUserAsync(userId).GetAwaiter().GetResult();
        }

        public string CreateUser(User user)
        {
            return CreateUserAsync(user).GetAwaiter().GetResult();
        }

        public bool UpdateUser(string userId, User user)
        {
            return UpdateUserAsync(userId, user).GetAwaiter().GetResult();
        }

        public bool DeleteUser(string userId)
        {
            return DeleteUserAsync(userId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<User>> GetUsersAsync()
        {
            var response = await client.GetAsync("api/User").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<User>>().ConfigureAwait(false);
        }

        private async Task<User> GetUserAsync(string userId)
        {
            var response = await client.GetAsync("api/User/" + userId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<User>().ConfigureAwait(false);
        }

        private async Task<string> CreateUserAsync(User user)
        {
            var response = await client.PostAsJsonAsync("api/User", user).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var userId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return userId.Substring(1, userId.Length - 2);
        }

        private async Task<bool> UpdateUserAsync(string userId, User user)
        {
            var response = await client.PutAsJsonAsync("api/User/" + userId, user).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteUserAsync(string userId)
        {
            var response = await client.DeleteAsync("api/User/" + userId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}
