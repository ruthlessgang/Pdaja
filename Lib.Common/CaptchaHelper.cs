using Lib.Common.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common
{
    public class CaptchaHelper
    {
        public bool ValidateCaptcha(string response)
        {
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            bool Valid = false;
            //Request to Google Server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create
            (" https://www.google.com/recaptcha/api/siteverify?secret=" + secret + "&response=" + response);
            try
            {
                //Google recaptcha Response
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();
                        var data = JsonConvert.DeserializeObject<CaptchaResponse>(jsonResponse);// Deserialize Json
                        Valid = Convert.ToBoolean(data.Success);
                    }
                }

                return Valid;
            }
            catch (WebException ex)
            {
                return false;
            }
        }
    }
}
