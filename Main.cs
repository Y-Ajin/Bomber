using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;

namespace Bomber
{
    public partial class Main : Form
    {
        delegate void SetTextCallback(string text);

        private Dictionary<string, Http> Https;
        private bool breakLoop;

        public Main()
        {
            InitializeComponent();
        }

        private void LoadBullets()
        {
            Https = new Dictionary<string, Http>();
            using (StreamReader sr = new StreamReader("bullet_list.py"))
            {
                string start = "";
                Dictionary<string, string> headers = new Dictionary<string, string>();
                string method = "";
                string url = "";
                string urlp = "";
                string data = "";
                string json = "";
                float delay = 0f;
                string line;

                string ConvertTo(string str)
                {
                    string result = "";
                    str = str.Replace("{", "").Replace("}", "").Replace("'", "\"");
                    var parr = str.Split(',');
                    for (int i = 0; i < parr.Length; i++)
                    {
                        var kv = parr[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (kv.Length == 0)
                        {
                            continue;
                        }
                        result += i == 0 ? "" : "&";
                        result += kv[0].Replace("\"", "").Trim() + "=" + (kv.Length > 1 ? kv[1].Replace("\"", "").Trim() : "");
                    }
                    return result;
                }

                string Copy(string str, int count)
                {
                    if (count > 0)
                        return Copy(str + str, --count);
                    else
                        return str;
                }

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("def"))
                    {
                        start = line;
                        headers = new Dictionary<string, string>();
                        method = "";
                        url = "";
                        urlp = "";
                        data = "";
                        json = "";
                        delay = 0f;
                    }
                    else if (start != "")
                    {
                        if (line.Contains("return"))
                        {
                            var arr = line.Split(new char[] { ',' }, 5);

                            method = arr[1].Replace("'", "").Replace("\"", "").Trim();
                            url = arr[2].Replace("'", "").Replace("\"", "").Trim();

                            if (arr.Length > 4)
                            {
                                //var pattern = "(?:params=({[^}]*}))?[}, ]*(?:data=({[^}]*}))?[}, ]*(?:json=({[^}]*}))?[}, ]*(?:delay=([0-9.]+))?";
                                var input = arr[4].Replace(")", "").Trim();
                                var pattern1 = "params=({[^}]*})";
                                var pattern2 = "data=({[^}]*})";
                                var pattern3 = "json=({[^}]*})";
                                var pattern4 = "delay=([0-9.]+)";
                                var groups1 = Regex.Match(input, pattern1).Groups;
                                var groups2 = Regex.Match(input, pattern2).Groups;
                                var groups3 = Regex.Match(input, pattern3).Groups;
                                var groups4 = Regex.Match(input, pattern4).Groups;

                                urlp = ConvertTo(groups1[1].Value);
                                data = ConvertTo(groups2[1].Value);

                                json = groups3[1].Value.Replace("'", "\"");

                                int kCount = 0;
                                int startCount = json.Count(c => c == '{'), endCount = json.Count(c => c == '}');
                                while (endCount < startCount)
                                {
                                    pattern3 = "json=({[^}]*}" + Copy("[^}]*}", kCount++) + ")";
                                    groups3 = Regex.Match(input, pattern3).Groups;
                                    json = groups3[1].Value.Replace("'", "\"");
                                    startCount = json.Count(c => c == '{'); 
                                    endCount = json.Count(c => c == '}');
                                }

                                delay = groups4[1].Value == "" ? 0f : Convert.ToSingle(groups4[1].Value);

                                if (urlp != "")
                                {
                                    url += "?" + urlp;
                                }
                            }

                            var name = start.Split('(')[0].Substring(start.IndexOf(" ") + 1);
                            var http = new Http
                            {
                                Method = method.ToUpper(),
                                Url = url,
                                Headers = headers,
                                Data = data != "" ? data : json,
                                Delay = delay
                            };

                            Https[name] = http;

                            start = "";
                            headers = new Dictionary<string, string>();
                            method = "";
                            url = "";
                            urlp = "";
                            data = "";
                            json = "";
                            delay = 0f;
                        }
                        else
                        {
                            if (line.Contains("headers") || line.Contains("''')"))
                                continue;
                            var key = line.Substring(0, line.IndexOf(":")).Trim();
                            if (key == "Content-Length") continue;
                            headers[key] = line.Substring(line.IndexOf(":") + 1).Trim();
                        }
                    }
                }
            }

            Bullets.Items.Clear();
            foreach (var http in Https)
            {
                Bullets.Items.Add(http.Key, true);
            }

            RefreshBullets.Text = string.Format("刷新({0})", Https.Count); 
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadBullets();
            #region Load Config
            if (File.Exists("Config.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Config.xml");

                XmlNode root = doc.FirstChild;
                if (root != null)
                {
                    XmlElement phone = root["Phone"];
                    if (phone != null)
                        PhoneValue.Text = phone.GetAttribute("value");
                    XmlElement times = root["Times"];
                    if (times != null)
                        TimesValue.Text = times.GetAttribute("value");
                    XmlElement delay = root["delay"];
                    if (delay != null)
                        DelayValue.Text = delay.GetAttribute("value");
                    XmlElement proxies = root["Proxies"];
                    if (proxies != null)
                    {
                        ProxyEnabled.Checked = proxies.GetAttribute("enabled") == "true";
                        foreach (XmlElement p in proxies)
                        {
                            ProxyValue.AppendText(p.GetAttribute("value") + "\n");
                        }
                    }
                }
            }
            #endregion
        }

        private void OnKeyPressInt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22)
            {
                if (!int.TryParse(Clipboard.GetText(), out _))
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void OnKeyPressFloat(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22)
            {
                if (!int.TryParse(Clipboard.GetText(), out _))
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == 8) return;
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '.')
                e.Handled = true;
        }

        private void SetText(string text)
        {
            if (Output.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                Output.AppendText(text);
                Output.Refresh();
                Output.ScrollToCaret();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var phone = PhoneValue.Text;
            var times = Convert.ToInt32(TimesValue.Text);
            var delay = Convert.ToSingle(DelayValue.Text);
            ProxyValue.Text = ProxyValue.Text.Replace("//", "/");
            var proxies = ProxyValue.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var proxyEnabled = ProxyEnabled.Checked;

            #region Save Config
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlConfig = xmlDoc.CreateElement("Config");
            XmlElement xmlPhone = xmlDoc.CreateElement("Phone");
            XmlElement xmlTimes = xmlDoc.CreateElement("Times");
            XmlElement xmlDelay = xmlDoc.CreateElement("Delay");
            XmlElement xmlProxies = xmlDoc.CreateElement("Proxies");
            
            xmlPhone.SetAttribute("value", phone);
            xmlTimes.SetAttribute("value", TimesValue.Text);
            xmlDelay.SetAttribute("value", DelayValue.Text);
            xmlProxies.SetAttribute("enabled", proxyEnabled ? "true" : "false");

            foreach (var p in proxies)
            {
                XmlElement xmlProxy = xmlDoc.CreateElement("Proxy");
                xmlProxy.SetAttribute("value", p);
                xmlProxies.AppendChild(xmlProxy);
            }

            xmlConfig.AppendChild(xmlPhone);
            xmlConfig.AppendChild(xmlTimes);
            xmlConfig.AppendChild(xmlDelay);
            xmlConfig.AppendChild(xmlProxies);
            xmlDoc.AppendChild(xmlConfig);

            xmlDoc.Save("Config.xml");
            #endregion

            var https = new Dictionary<string, Http>();

            for (int i = 0; i < Bullets.Items.Count; i++)
            {
                if (Bullets.GetItemChecked(i))
                {
                    string key = (string)Bullets.Items[i];
                    var http = new Http
                    {
                        Method = Https[key].Method,
                        Url = Https[key].Url.Replace("+target+", phone).Replace("=target", "=" + phone),
                        Headers = Https[key].Headers,
                        Data = Https[key].Data.Replace("'+target+'", phone).Replace("target", phone),
                        Delay = Https[key].Delay
                    };
                    https[key] = http;
                }
            }

            Output.Clear();
            Output.Refresh();

            Thread th = new Thread(() =>
            {
                breakLoop = false;

                for (int i = 1; i < times + 1; i++)
                {
                    if (breakLoop)
                    {
                        breakLoop = false;
                        SetText(">> 停止循环...\n\n");
                        return;
                    }

                    SetText(">> 第" + i + "次循环开始\n\n");
                    foreach (var http in https)
                    {
                        if (breakLoop)
                        {
                            breakLoop = false;
                            SetText(">> 停止循环...\n\n");
                            return;
                        }

                        SetText("目标名称: " + http.Key + "\n");
                        var r = Http.Request(http.Value, !proxyEnabled || proxies.Length == 0 ? null : proxies[new Random().Next(0, proxies.Length)]);
                        SetText("输出结果: " + r + "\n\n");
                        if (http.Value.Delay > 0f)
                        {
                            SetText("请稍等...\n\n");
                            Thread.Sleep((int)(http.Value.Delay * 1000f));
                        }
                    }
                    SetText(">> 第" + i + "次循环结束\n\n");
                    Thread.Sleep((int)(delay * 1000f));
                }
            });
            th.Start();
        }

        private void AllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Bullets.Items.Count; i++)
            {
                Bullets.SetItemChecked(i, true);
            }
        }

        private void ReverseSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Bullets.Items.Count; i++)
            {
                Bullets.SetItemChecked(i, !Bullets.GetItemChecked(i));
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            breakLoop = true;
        }

        private void TestProxy_Click(object sender, EventArgs e)
        {
            var proxies = ProxyValue.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            #region Save or Update Proxies
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlConfig = null;
            if (File.Exists("Config.xml"))
            {
                xmlDoc.Load("Config.xml");
                xmlConfig = xmlDoc.FirstChild;
            }
            else
            {
                xmlConfig = xmlDoc.CreateElement("Config");
                xmlDoc.AppendChild(xmlConfig);
            }
            XmlElement xmlProxies = xmlConfig["Proxies"];
            if (xmlProxies == null)
            {
                xmlProxies = xmlDoc.CreateElement("Proxies");
                xmlConfig.AppendChild(xmlProxies);
            }
            xmlProxies.RemoveAll();
            xmlProxies.SetAttribute("enabled", ProxyEnabled.Checked ? "true" : "false");
            foreach (var p in proxies)
            {
                XmlElement xmlProxy = xmlDoc.CreateElement("Proxy");
                xmlProxy.SetAttribute("value", p);
                xmlProxies.AppendChild(xmlProxy);
            }
            xmlDoc.Save("Config.xml");
            #endregion

            Output.Clear();
            Output.Refresh();

            Thread th = new Thread(() =>
            {
                WebResponse response = null;
                StreamReader r = null;

                try
                {
                    foreach (var p in proxies)
                    {
                        var request = (HttpWebRequest)WebRequest.Create("http://httpbin.org/ip");

                        var proxy = new WebProxy(p)
                        {
                            BypassProxyOnLocal = true
                        };
                        request.Proxy = proxy;

                        SetText("开始测试: " + p + "\n");

                        try
                        {

                            response = request.GetResponse();
                            r = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            SetText("测试结果: " + r.ReadToEnd() + "\n\n");
                        }
                        catch (WebException wex)
                        {
                            SetText("测试出错: " + wex.Message + "\n\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    SetText("程序出错: " + ex.Message + "\n\n");
                }
                finally
                {
                    if (response != null)
                        response.Close();
                    if (r != null)
                        r.Close();
                }
            })
            {
                Name = "TestProxy"
            };
            th.Start();
        }

        private void RefreshBullets_Click(object sender, EventArgs e)
        {
            LoadBullets();
        }
    }
}
