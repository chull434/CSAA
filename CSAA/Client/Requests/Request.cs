using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Requests
{
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
