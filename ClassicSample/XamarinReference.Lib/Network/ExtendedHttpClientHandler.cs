using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace XamarinReference.Lib.Network
{
    public class ExtendedHttpClientHandler : HttpClientHandler
    {
        protected static List<string> SplitOnCommaAndOrder(string input)
        {
            return Enumerable.ToList<string>(Enumerable.Select(Enumerable.OrderBy(Enumerable.Select((IEnumerable<string>)input.Split(new char[1]
            {
        ','
            }, StringSplitOptions.RemoveEmptyEntries), p => new
            {
                p = p,
                item = p.Trim()
            }), param0 => param0.item), param0 => param0.item));
        }

        protected static void SetHeaders(List<KeyValuePair<string, string>> headers, HttpResponseMessage message)
        {
            foreach (KeyValuePair<string, string> keyValuePair in headers)
            {
                string key = keyValuePair.Key;
                string str1 = keyValuePair.Value;
                try
                {
                    if (key == "Allow")
                    {
                        foreach (string str2 in ExtendedHttpClientHandler.SplitOnCommaAndOrder(str1))
                            message.Content.Headers.Allow.Add(str2);
                    }
                    else if (key == "Content-Disposition")
                    {
                        ContentDispositionHeaderValue parsedValue;
                        if (ContentDispositionHeaderValue.TryParse(str1, out parsedValue))
                            message.Content.Headers.ContentDisposition = parsedValue;
                    }
                    else if (key == "Content-Encoding")
                    {
                        foreach (string str2 in ExtendedHttpClientHandler.SplitOnCommaAndOrder(str1))
                            message.Content.Headers.ContentEncoding.Add(str2);
                    }
                    else if (key == "Content-Language")
                    {
                        foreach (string str2 in ExtendedHttpClientHandler.SplitOnCommaAndOrder(str1))
                            message.Content.Headers.ContentLanguage.Add(str2);
                    }
                    else if (key == "Content-Length")
                    {
                        long result;
                        if (long.TryParse(str1, out result))
                            message.Content.Headers.ContentLength = new long?(result);
                    }
                    else if (key == "Content-Location")
                    {
                        try
                        {
                            message.Content.Headers.ContentLocation = new Uri(str1);
                        }
                        catch
                        {
                        }
                    }
                    else if (!(key == "Content-MD5"))
                    {
                        if (key == "Content-Range")
                        {
                            ContentRangeHeaderValue parsedValue;
                            if (ContentRangeHeaderValue.TryParse(str1, out parsedValue))
                                message.Content.Headers.ContentRange = parsedValue;
                        }
                        else if (key == "Content-Type")
                        {
                            MediaTypeHeaderValue parsedValue;
                            if (MediaTypeHeaderValue.TryParse(str1, out parsedValue))
                                message.Content.Headers.ContentType = parsedValue;
                        }
                        else if (key == "Expires")
                        {
                            double result;
                            if (double.TryParse(str1, out result))
                                message.Content.Headers.Expires = new DateTimeOffset?(DateTimeOffset.Now.AddSeconds(result));
                        }
                        else if (key == "LastModified")
                        {
                            DateTimeOffset result;
                            if (DateTimeOffset.TryParse(str1, out result))
                                message.Content.Headers.LastModified = new DateTimeOffset?(result);
                        }
                        else
                            message.Headers.Add(key, str1);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0} : {1} {2} Exception: {3}", (object)key, (object)str1, (object)Environment.NewLine, (object)ex.Message));
                }
            }
        }
    }
}
