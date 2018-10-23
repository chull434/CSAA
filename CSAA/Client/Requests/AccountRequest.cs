using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CSAA.Models;

namespace Client.Requests
{
    public class AccountRequest : Request
    {
        public bool Register(User user)
        {
            return RegisterAsync(user).GetAwaiter().GetResult();
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var response = await client.PostAsJsonAsync("api/Account/Register", user).ConfigureAwait(false);
            var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public bool Login(string email, string password)
        {
            return LoginAsync(email, password).GetAwaiter().GetResult();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var loginData = new Dictionary<string, string>();
            loginData.Add("grant_type", "password");
            loginData.Add("username", email);
            loginData.Add("password", password);

            var response = await client.PostAsync("/token", new FormUrlEncodedContent(loginData)).ConfigureAwait(false);

            var message = await response.Content.ReadAsAsync<LoginData>().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", message.access_token);

            return response.IsSuccessStatusCode;
        }
    }

    public class LoginData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string userName { get; set; }
    }
}
