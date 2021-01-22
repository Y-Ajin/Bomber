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
        public string Data { get; set; }
        public float Delay { get; set; }

        public static string Request(Http http, string proxy = null)
        {
            string result = "";
            HttpWebResponse response = null;
            StreamReader r = null;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                var request = (HttpWebRequest)WebRequest.Create(http.Url);

                request.Method = http.Method;
                request.CookieContainer = new CookieContainer();
                request.AllowAutoRedirect = true;
                request.Credentials = CredentialCache.DefaultCredentials;
                if (proxy != null)
                    request.Proxy = new WebProxy(proxy);

                foreach (var h in http.Headers)
                {
                    if (h.Key.Equals("Host", StringComparison.CurrentCultureIgnoreCase))
                        request.Host = h.Value;
                    else if (h.Key.Equals("Connection", StringComparison.CurrentCultureIgnoreCase))
                        request.KeepAlive = true;
                    else if (h.Key.Equals("Content-Type", StringComparison.CurrentCultureIgnoreCase))
                        request.ContentType = h.Value;
                    else if (h.Key.Equals("User-Agent", StringComparison.CurrentCultureIgnoreCase))
                        request.UserAgent = h.Value;
                    else if (h.Key.Equals("Accept", StringComparison.CurrentCultureIgnoreCase))
                        request.Accept = h.Value;
                    else if (h.Key.Equals("Referer", StringComparison.CurrentCultureIgnoreCase))
                        request.Referer = h.Value;
                    else if (h.Key.Equals("Cookie", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var arrv = h.Value.Split(';');
                        foreach (var v in arrv)
                        {
                            var name = v.Substring(0, v.IndexOf("=")).Trim();
                            var value = v.Substring(v.IndexOf("=") + 1).Trim();
                            request.CookieContainer.Add(new Cookie(name, value, "/", request.Host));
                        }
                    }
                    else
                        request.Headers.Set(h.Key, h.Value);
                }

                if (request.Method != "GET")
                {
                    var d = Encoding.UTF8.GetBytes(http.Data);
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
