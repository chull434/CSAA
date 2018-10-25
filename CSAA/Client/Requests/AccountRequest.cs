using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CSAA.Models;

namespace Client.Requests
{
    public class AccountRequest : Request, IAccountRequest
    {
        public AccountRequest() : base()
        {

        }

        public AccountRequest(IHttpClient client) : base(client)
        {

        }

        public bool Register(User user)
        {
            return RegisterAsync(user).GetAwaiter().GetResult();
        }

        private async Task<bool> RegisterAsync(User user)
        {
            var response = await client.PostAsJsonAsync("api/Account/Register", user).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}
