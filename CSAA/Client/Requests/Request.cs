using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client.Requests
{
    public class Request
    {
        protected IHttpClient client;

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
    }
}
