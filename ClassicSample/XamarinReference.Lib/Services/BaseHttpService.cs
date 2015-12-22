
using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinReference.Lib.Helper;
using XamarinReference.Lib.Interface;

namespace XamarinReference.Lib.Services
{
    public abstract class BaseHttpService
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        protected HttpClient CreateClient()
        {
            HttpClientHandler handler = ((ICreateHttpClientHelper)Mvx.Resolve<ICreateHttpClientHelper>()).CreateHandler();
            if (!string.IsNullOrEmpty(this.UserName))
                handler.Credentials = (ICredentials)new NetworkCredential(this.UserName, this.Password);
            return new HttpClient((HttpMessageHandler)handler)
            {
                Timeout = TimeSpan.FromMinutes(15.0)
            };
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri, List<KeyValuePair<string, string>> headers)
        {
            HttpClient client = (HttpClient)null;
            HttpResponseMessage httpResponseMessage1;
            try
            {
                client = this.CreateClient();
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> keyValuePair in headers)
                    {
                        KeyValuePair<string, string> header = keyValuePair;
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        header = new KeyValuePair<string, string>();
                    }
                    List<KeyValuePair<string, string>>.Enumerator enumerator = new List<KeyValuePair<string, string>>.Enumerator();
                }
                HttpResponseMessage httpResponseMessage = await client.GetAsync(uri);
                HttpResponseMessage response = httpResponseMessage;
                httpResponseMessage = (HttpResponseMessage)null;
                httpResponseMessage1 = response;
            }
            finally
            {
                client.Dispose();
            }
            return httpResponseMessage1;
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri uri, List<KeyValuePair<string, string>> headers)
        {
            HttpClient client = (HttpClient)null;
            HttpResponseMessage response = (HttpResponseMessage)null;
            HttpResponseMessage httpResponseMessage1;
            try
            {
                client = this.CreateClient();
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> keyValuePair in headers)
                    {
                        KeyValuePair<string, string> header = keyValuePair;
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        header = new KeyValuePair<string, string>();
                    }
                    List<KeyValuePair<string, string>>.Enumerator enumerator = new List<KeyValuePair<string, string>>.Enumerator();
                }
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(uri);
                httpResponseMessage1 = httpResponseMessage;
            }
            finally
            {
                Memory.DisposeGarbage((IDisposable)response, (IDisposable)client);
            }
            return httpResponseMessage1;
        }

        private async Task<HttpResponseMessage> SendAsync(Uri uri, List<KeyValuePair<string, string>> headers, string content, string httpMethod)
        {
            HttpClient client = (HttpClient)null;
            HttpRequestMessage request = (HttpRequestMessage)null;
            StringContent sc = (StringContent)null;
            HttpResponseMessage httpResponseMessage1;
            try
            {
                client = this.CreateClient();
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> keyValuePair in headers)
                    {
                        KeyValuePair<string, string> header = keyValuePair;
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        header = new KeyValuePair<string, string>();
                    }
                    List<KeyValuePair<string, string>>.Enumerator enumerator = new List<KeyValuePair<string, string>>.Enumerator();
                }
                sc = new StringContent(content, Encoding.UTF8, "application/json");
                HttpMethod method = new HttpMethod(httpMethod);
                request = new HttpRequestMessage()
                {
                    Content = (HttpContent)sc,
                    Method = method,
                    RequestUri = uri
                };
                HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
                HttpResponseMessage responseMessage = httpResponseMessage;
                httpResponseMessage = (HttpResponseMessage)null;
                httpResponseMessage1 = responseMessage;
            }
            finally
            {
                if (client != null)
                    client.Dispose();
                if (request != null)
                    request.Dispose();
                if (sc != null)
                    sc.Dispose();
            }
            return httpResponseMessage1;
        }

        public async Task<HttpResponseMessage> PostAsync(Uri uri, List<KeyValuePair<string, string>> headers, string content)
        {
            HttpResponseMessage httpResponseMessage = await this.SendAsync(uri, headers, content, "POST");
            return httpResponseMessage;
        }

        public async Task<HttpResponseMessage> PatchAsync(Uri uri, List<KeyValuePair<string, string>> headers, string content)
        {
            HttpResponseMessage httpResponseMessage = await this.SendAsync(uri, headers, content, "PATCH");
            return httpResponseMessage;
        }

        protected static Uri GetEscapedUri(string format, params object[] args)
        {
            return new Uri(Uri.EscapeUriString(string.Format((IFormatProvider)CultureInfo.InvariantCulture, format, args)));
        }

        protected void DealWithErrors(Exception ex)
        {
        }
    }
}
