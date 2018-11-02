using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Requests
{
    /// <summary>
    /// Request class for HTTP client requests. Includes HTTP response method to check response of HTTP Client. 
    /// </summary>
    public class Request
    {
        protected IHttpClient client;

        #region Constructor

        public Request(IHttpClient client)
        {
            this.client = client;
        }

        #endregion

        #region Helper Methods

        protected static async Task<string> CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return message;
            }
        }

        #endregion
    }
}
