﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CSAA.Models;

namespace Client.Requests
{
    public class HttpClient : System.Net.Http.HttpClient, IHttpClient
    {
        public HttpClient()
        {
            BaseAddress = new Uri("http://localhost:62676/");
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value)
        {
            return ((System.Net.Http.HttpClient)this).PostAsJsonAsync(requestUri, value);
        }

        public Task<HttpResponseMessage> PostAsync(string token, FormUrlEncodedContent formUrlEncodedContent)
        {
            return ((System.Net.Http.HttpClient) this).PostAsync(token, formUrlEncodedContent);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return ((System.Net.Http.HttpClient)this).GetAsync(requestUri);
            return ((System.Net.Http.HttpClient)this).GetAsync(requestUri);

        }

        public void SetAuthorizationToken(string token)
        {
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
