using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Bomber
{
    public class Http
    {
        public string Method { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string PostData { get; set; }
        public float Delay { get; set; }

        public static string Request(Http http, string proxy = null)
        {
            string result = "";
            HttpWebResponse response = null;
            StreamReader r = null;
            CookieContainer cc = new CookieContainer();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(http.Url);

                request.Method = http.Method;
                request.CookieContainer = cc;
                if (proxy != null)
                    request.Proxy = new WebProxy(proxy);

                foreach (var h in http.Headers)
                {
                    if (h.Key == "Content-Type")
                        request.ContentType = h.Value;
                    else if (h.Key == "User-Agent")
                        request.UserAgent = h.Value;
                    else if (h.Key == "Accept")
                        request.Accept = h.Value;
                    else if (h.Key == "Referer")
                        request.Referer = h.Value;
                    else
                        request.Headers.Set(h.Key, h.Value);
                }

                if (request.Method == "POST")
                {
                    var d = Encoding.UTF8.GetBytes(http.PostData);
                    request.ContentLength = d.Length;

                    Stream s = request.GetRequestStream();
                    s.Write(d, 0, d.Length);
                    s.Close();
                }

                response = (HttpWebResponse)request.GetResponse();
                r = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = r.ReadToEnd();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                if (response != null)
                    response.Close();
                if (r != null)
                    r.Close();
            }

            return result;
        }
    }
}
