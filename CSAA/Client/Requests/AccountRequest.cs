using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using CSAA.ServiceModels;
using Newtonsoft.Json;

namespace Client.Requests
{
    /// <summary>
    /// This sets up the Account Request class.
    /// </summary>
    public class AccountRequest : Request, IAccountRequest
    {
        #region Constructor

        public AccountRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public string Register(User user)
        {
            return RegisterAsync(user).GetAwaiter().GetResult();
        }

        public string Login(string email, string password)
        {
            return LoginAsync(email, password).GetAwaiter().GetResult();
        }

        public string Logout()
        {
            return LogoutAsync().GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<string> LogoutAsync()
        {
            var response = await client.PostAsync("api/Account/Logout",null).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }

        private async Task<string> RegisterAsync(User user)
        {
            var response = await client.PostAsJsonAsync("api/Account/Register", user).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var httpErrorObject = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var anonymousErrorObject = new { message = "", ModelState = new Dictionary<string, string[]>() };
                var deserializedErrorObject = JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);
                var errors = deserializedErrorObject.ModelState[""];
                var errorMessage = "";
                for (var i = 0; i < errors.Length; i++)
                {
                    var error = errors[i];
                    errorMessage += error;
                    if (i < errors.Length - 1) errorMessage += " ";
                }
                return errorMessage;
            }

            return string.Empty;
        }

        private async Task<string> LoginAsync(string email, string password)
        {
            var loginData = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                { "username", email},
                { "password", password}
            };

            var response = await client.PostAsync("/token", new FormUrlEncodedContent(loginData)).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsAsync<LoginErrorMessage>().ConfigureAwait(false);
                return errorMessage.error_description;
            }

            var LoginData = await response.Content.ReadAsAsync<LoginData>().ConfigureAwait(false);
            client.SetAuthorizationToken(LoginData.access_token);

            return string.Empty;
        }

        #endregion
    }

    /// <summary>
    /// Accessor and mutator methods for the Login Error message.
    /// </summary>
    public class LoginErrorMessage
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }

    /// <summary>
    /// Accessor and mutator methods for the Login data.
    /// </summary>
    public class LoginData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string userName { get; set; }
    }
}
