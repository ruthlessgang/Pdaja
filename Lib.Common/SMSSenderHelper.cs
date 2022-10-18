using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common
{
    public class SMSSenderHelper
    {
        public string SendSMS(string message, string phone,string token)
        {
            var urlTokenSMS = ConfigurationManager.AppSettings["URL.TOKEN.SMS"];

            var stringURLToken = string.Format("{0}nomorhp={1}&message={2}",
                urlTokenSMS,
                phone,
                message);

            var apiClient = new Lib.Common.RestClient();
            var headerRequest = new Dictionary<string, string>();
            headerRequest.Add("Authorization", string.Format("{0} {1}", "Bearer", token));

            ServicePointManager
    .ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;
            var result = apiClient.Get(stringURLToken, headerRequest);
            return result;
        }
    }
}
