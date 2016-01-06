using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Java.Net;
using Org.Apache.Http;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Entity;

using Android.App;
using Android.Content;
using Android.Net.Http;
using Android.Runtime;
using Android.Views;
using Android.Widget;


using OkHttp;
using OkHttp.Okio;

using XamarinReference.Lib.Network;
using XamarinReference.Lib.Interface;

namespace XamarinReference.Droid.Network
{
    public class AndriodHttpClientHandler : ExtendedHttpClientHandler
    {
    //    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    //    {
    //        AndroidHttpClient client = null;
    //        HttpRequestBase httpRequest = null;
    //        IHttpResponse response = null;

    //        try
    //        {
    //            Debug.WriteLine(string.Format("SendAsync: {0} {1}", request.Method, request.RequestUri));

    //            client = AndroidHttpClient.NewInstance("EY.Core.Android.HttpDownloader");

    //            httpRequest = GetMethod(request);

    //            if (request.Headers != null && request.Headers.Count() > 0)
    //            {
    //                foreach (var item in request.Headers)
    //                {
    //                    Debug.WriteLine(string.Format("RequestHeader: {0} : {1}", item.Key, item.Value.First()));
    //                    httpRequest.AddHeader(item.Key, item.Value.First());
    //                }
    //            }

    //            if (request.Content == null)
    //            {
    //                response = await client.ExecuteAsync(httpRequest);
    //            }

    //            else
    //            {
    //                HttpEntityEnclosingRequestBase moronic = httpRequest as HttpEntityEnclosingRequestBase;

    //                foreach (var item in request.Content.Headers)
    //                {
    //                    // This header is inserted for you
    //                    if (item.Key == "Content-Length")
    //                    {
    //                        continue;
    //                    }

    //                    else
    //                    {
    //                        moronic.AddHeader(item.Key, item.Value.First());
    //                    }
    //                }

    //                var stream = await request.Content.ReadAsStreamAsync();

    //                moronic.Entity = new InputStreamEntity(stream, stream.Length);

    //                response = await client.ExecuteAsync(moronic);
    //            }

    //            HttpContent responseContent;

    //            if (response.Entity == null)
    //            {
    //                responseContent = new StringContent("");
    //            }

    //            else
    //            {
    //                responseContent = new StreamContent(response.Entity.Content);
    //            }

    //            var headers = (from p in response.GetAllHeaders()
    //                           orderby p.Name
    //                           select new KeyValuePair<string, string>(p.Name, p.Value)).ToList();

    //            HttpResponseMessage responseMessage = new HttpResponseMessage
    //            {
    //                Content = responseContent,
    //                RequestMessage = request,
    //                StatusCode = (HttpStatusCode)response.StatusLine.StatusCode
    //            };

    //            SetHeaders(headers, responseMessage);

    //            return responseMessage;
    //        }

    //        finally
    //        {
    //            if (response != null)
    //            {
    //                response.Dispose();
    //            }
    //            if (httpRequest != null)
    //            {
    //                httpRequest.Dispose();
    //            }
    //            if (client != null)
    //            {
    //                client.Dispose();
    //            }
    //        }
    //    }

    //    protected HttpRequestBase GetMethod(HttpRequestMessage request)
    //    {
    //        switch (request.Method.Method.ToUpper())
    //        {
    //            case "GET":
    //                return new HttpGet(request.RequestUri.AbsoluteUri);

    //            case "HEAD":
    //                return new HttpHead(request.RequestUri.AbsoluteUri);

    //            case "PATCH":
    //                return new HttpPatch(request.RequestUri.AbsoluteUri);

    //            case "POST":
    //                return new HttpPost(request.RequestUri.AbsoluteUri);

    //            case "PUT":
    //                return new HttpPut(request.RequestUri.AbsoluteUri);

    //            default:
    //                throw new ArgumentException("Unsupported HTTP Method");
    //        }
    //    }
    //}

    //public class NSUrlConnectionHandlerCreator : ICreateHttpClientHelper
    //{
    //    public HttpClientHandler CreateHandler()
    //    {
    //        return new AndriodHttpClientHandler();
    //    }
    //}

    //public class HttpPatch : HttpEntityEnclosingRequestBase
    //{
    //    override public string Method
    //    {
    //        get { return "PATCH"; }
    //    }

    //    public HttpPatch() : base()
    //    {

    //    }

    //    public HttpPatch(string uri)
    //    {
    //        URI = new Java.Net.URI(uri);
    //    }

    //    public HttpPatch(URI uri)
    //    {
    //        URI = uri;
    //    }
    }
}