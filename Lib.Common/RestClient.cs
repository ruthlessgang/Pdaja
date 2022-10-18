using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Lib.Common
{
    public class RestClient
    {
        public string Post(string requestUrl, Object payload, int responseTimeout = 0, Dictionary<string, string> headers = null)
        {
            string result = string.Empty;
            string fn = ConfigurationManager.AppSettings["LogFileName"];
            try
            {
                var pay = JsonConvert.SerializeObject(payload);

                string fileName = fn + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (!File.Exists(fileName))
                {
                    var myfile = File.Create(fileName);
                    myfile.Close();
                }

                using (StreamWriter w = new StreamWriter(fileName, true))
                {
                    w.WriteLine("new request (" + System.DateTime.Now.ToString() + ") : ");
                    w.WriteLine(requestUrl);
                    w.WriteLine("request : " + pay);

                    w.Close();
                }

                int timeout = 0;
                int.TryParse(ConfigurationManager.AppSettings["RequestTimeout.Second"], out timeout);

                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";

                // add headers
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> h in headers)
                    {
                        request.Headers.Add(h.Key, h.Value);
                    }
                }

                if (responseTimeout > 0)
                    request.Timeout = responseTimeout;
                else
                    request.Timeout = timeout * 1000;

                ServicePointManager
      .ServerCertificateValidationCallback +=
      (sender, cert, chain, sslPolicyErrors) => true;

                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    var p = JsonConvert.SerializeObject(payload);
                    writer.Write(p);
                }

                // Log every post for testing purpose only

                //using (var writer = new StreamWriter(request.GetRequestStream()))
                //{
                //    System.IO.StreamWriter file = new System.IO.StreamWriter(fileStream);
                //file.WriteLine("new request (" + System.DateTime.Now.ToString() + ") : ");
                //file.WriteLine(requestUrl);
                //file.WriteLine(p);

                //file.Close();
                //writer.Write(p);
                //}
                // end of Log every post for testing purpose only

                var response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }

                using (StreamWriter ww = new StreamWriter(fileName, true))
                {
                    //System.IO.StreamWriter ww = new System.IO.StreamWriter(fileName);
                    ww.WriteLine("result : " + result);
                    ww.Close();
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                string LogErrorFile = fn + "LogError_" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";
                using (StreamWriter w = new StreamWriter(LogErrorFile, true))
                {
                    w.WriteLine("new request (" + System.DateTime.Now.ToString() + ") : ");
                    w.WriteLine(requestUrl);
                    w.WriteLine("request : " + ex.Message);

                    w.Close();
                }
                result = ex.Message;
            }
            return result;
        }

        public string Get(string requestUrl, Dictionary<string, string> headers = null)
        {
            string result = string.Empty;
            try
            {
                string fn = ConfigurationManager.AppSettings["LogFileName"];
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Method = "GET";

                string fileName = fn + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (!File.Exists(fileName))
                {
                    var myfile = File.Create(fileName);
                    myfile.Close();
                }

                using (StreamWriter w = new StreamWriter(fileName, true))
                {
                    w.WriteLine("new request (" + System.DateTime.Now.ToString() + ") : ");
                    w.WriteLine(requestUrl);

                    w.Close();
                }

                //request.Headers.Add("Accept-Encoding", "gzip,deflate");
                ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
                // add headers
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> h in headers)
                    {
                        request.Headers.Add(h.Key, h.Value);
                    }
                }

                using (var apiResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(apiResponse.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> PostAsync(string requestUrl, object payload, int timeout = 0)
        {
            string jsonData = JsonConvert.SerializeObject(payload);

            using (HttpClient httpClient = new HttpClient())
            {
                if (timeout != 0) httpClient.Timeout = TimeSpan.FromSeconds(timeout);

                //HttpResponseMessage response = await httpClient.PostAsJsonAsync(requestUrl, payload);
                HttpResponseMessage response = httpClient.PostAsync(requestUrl, new StringContent(new JavaScriptSerializer().Serialize(payload), Encoding.UTF8, "application/json")).Result;

                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
        }
    }
}