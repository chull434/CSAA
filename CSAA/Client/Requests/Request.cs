using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client.Requests
{
    public class Request
    {
        protected IHttpClient client;

        #region Constructors

        public Request()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62676/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Request(IHttpClient client)
        {
            this.client = client;
        }

        #endregion

        #region Helper Methods

        protected static async Task<bool> CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return false;
            }
        }

        #endregion
    }
}
