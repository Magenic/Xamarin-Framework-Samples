using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using UIKit;
using Foundation;
using CoreFoundation;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Network;

namespace XamarinReference.iOS.Network
{
    public class NSUrlConnectionHandler:ExtendedHttpClientHandler
    {
        //this is a test
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var urlRequest = new NSMutableUrlRequest
            {
                HttpMethod = request.Method.Method,
                Url = NSUrl.FromString(request.RequestUri.AbsoluteUri),
                AllowsCellularAccess = true,
            };


            var dictionary = new NSMutableDictionary();

            if (request.Headers != null && request.Headers.Count() > 0)
            {
                foreach (var item in request.Headers)
                {
                    dictionary.SetValueForKey((NSString)item.Value.First(), (NSString)item.Key);
                }
            }

            if (request.Content != null)
            {
                foreach (var item in request.Content.Headers)
                {
                    dictionary.SetValueForKey((NSString)item.Value.First(), (NSString)item.Key);
                }
            }

            urlRequest.Headers = dictionary;

            if (request.Content != null)
            {
                using (Stream requestStream = await request.Content.ReadAsStreamAsync())
                {
                    urlRequest.Body = NSData.FromStream(requestStream);
                }
            }

            try
            {
                NSUrlAsyncResult response = await NSUrlConnection.SendRequestAsync(urlRequest, NSOperationQueue.MainQueue);

                NSHttpUrlResponse httpResponse = response.Response as NSHttpUrlResponse;

                HttpContent responseContent = null;

                if (response.Data == null)
                {
                    responseContent = new StringContent("");
                }

                else
                {
                    responseContent = new StreamContent(response.Data.AsStream());
                }

                HttpResponseMessage responseMessage = new HttpResponseMessage
                {
                    Content = responseContent,
                    RequestMessage = request,
                    StatusCode = (HttpStatusCode)int.Parse(httpResponse.StatusCode.ToString())
                };

                var headers = (from p in httpResponse.AllHeaderFields.Keys
                               let key = p.ToString()
                               let val = httpResponse.AllHeaderFields[p].ToString()
                               orderby key
                               select new KeyValuePair<string, string>(key, val)).ToList();

                SetHeaders(headers, responseMessage);

                return responseMessage;
            }

            catch (NSErrorException ex)
            {
                throw new HttpRequestException(ex.Error.LocalizedDescription, ex);
            }

            catch (Exception ex)
            {
                throw new HttpRequestException("An error occurred while sending the request.", ex);
            }
        }
    }

    public class NSUrlConnectionHandlerCreator : ICreateHttpClientHelper
    {
        public HttpClientHandler CreateHandler()
        {
            return new NSUrlConnectionHandler();
        }
    }
}
