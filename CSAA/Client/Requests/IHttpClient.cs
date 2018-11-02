using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Requests
{
    public interface IHttpClient
    {
        Uri BaseAddress { get; set; }
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value);
        Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T value);

        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(string token, FormUrlEncodedContent formUrlEncodedContent);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);

        void SetAuthorizationToken(string token);
    }
}
