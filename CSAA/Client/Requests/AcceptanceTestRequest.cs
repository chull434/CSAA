using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public class AcceptanceTestRequest : Request, IAcceptanceTestRequest
    {
        #region Constructor

        public AcceptanceTestRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<AcceptanceTest> GetAcceptanceTests()
        {
            return GetAcceptanceTestsAsync().GetAwaiter().GetResult();
        }

        public AcceptanceTest GetAcceptanceTestById(string acceptanceTestId)
        {
            return GetAcceptanceTestByIdAsync(acceptanceTestId).GetAwaiter().GetResult();
        }

        public string CreateAcceptanceTest(AcceptanceTest acceptanceTest)
        {
            return CreateAcceptanceTestAsync(acceptanceTest).GetAwaiter().GetResult();
        }

        public bool UpdateAcceptanceTest(string acceptanceTestId, AcceptanceTest acceptanceTest)
        {
            return UpdateAcceptanceTestAsync(acceptanceTestId, acceptanceTest).GetAwaiter().GetResult();
        }

        public bool DeleteAcceptanceTest(string acceptanceTestId)
        {
            return DeleteAcceptanceTestAsync(acceptanceTestId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<AcceptanceTest>> GetAcceptanceTestsAsync()
        {
            var response = await client.GetAsync("api/AcceptanceTest").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<AcceptanceTest>>().ConfigureAwait(false);
        }

        private async Task<AcceptanceTest> GetAcceptanceTestByIdAsync(string acceptanceTestId)
        {
            var response = await client.GetAsync("api/AcceptanceTest/" + acceptanceTestId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<AcceptanceTest>().ConfigureAwait(false);
        }

        private async Task<string> CreateAcceptanceTestAsync(AcceptanceTest acceptanceTest)
        {
            var response = await client.PostAsJsonAsync("api/AcceptanceTest", acceptanceTest).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var acceptanceTestId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return acceptanceTestId.Substring(1, acceptanceTestId.Length - 2);
        }

        private async Task<bool> UpdateAcceptanceTestAsync(string acceptanceTestId, AcceptanceTest acceptanceTest)
        {
            var response = await client.PutAsJsonAsync("api/AcceptanceTest/" + acceptanceTestId, acceptanceTest).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteAcceptanceTestAsync(string acceptanceTestId)
        {
            var response = await client.DeleteAsync("api/AcceptanceTest/" + acceptanceTestId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion


    }
}
