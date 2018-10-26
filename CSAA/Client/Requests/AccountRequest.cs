using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSAA.Models;

namespace Client.Requests
{
    public class AccountRequest : Request, IAccountRequest
    {
        #region Constructor

        public AccountRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public bool Register(User user)
        {
            return RegisterAsync(user).GetAwaiter().GetResult();
        }

        public bool Login(string email, string password)
        {
            return LoginAsync(email, password).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<bool> RegisterAsync(User user)
        {
            var response = await client.PostAsJsonAsync("api/Account/Register", user).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }

        private async Task<bool> LoginAsync(string email, string password)
        {
            var loginData = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                { "username", email},
                { "password", password}
            };

            var response = await client.PostAsync("/token", new FormUrlEncodedContent(loginData)).ConfigureAwait(false);

            await CheckResponse(response).ConfigureAwait(false);

            var message = await response.Content.ReadAsAsync<LoginData>().ConfigureAwait(false);
            client.SetAuthorizationToken(message.access_token);

            return true;
        }

        #endregion
    }

    public class LoginData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string userName { get; set; }
    }
}
