using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Bomber
{
    public class Http
    {
        public string Name { get; set; }
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
                HttpWebRequest request = null;

                if (http.Url.StartsWith("https", StringComparison.OrdinalIgnoreCase)) // https请求
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 
                                                         | SecurityProtocolType.Tls
                                                         | SecurityProtocolType.Tls11
                                                         | SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    request = (HttpWebRequest)WebRequest.Create(http.Url);
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                    request = (HttpWebRequest)WebRequest.Create(http.Url);

                request.CookieContainer = new CookieContainer();
                request.AllowAutoRedirect = true;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = http.Method;

                if (proxy != null)
                {
                    var p = new WebProxy(proxy)
                    {
                        BypassProxyOnLocal = true
                    };
                    request.Proxy = p;
                }

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
                        var container = new CookieContainer();
                        foreach (var v in arrv)
                        {
                            var name = v.Substring(0, v.IndexOf("=")).Trim();
                            var value = v.Substring(v.IndexOf("=") + 1).Trim();
                            var cookie = new Cookie(name, value, "/", request.Host);
                            try
                            {
                                container.Add(cookie);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        request.CookieContainer = container;
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
