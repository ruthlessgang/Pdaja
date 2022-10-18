using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;

namespace Lib.Common
{
    public class EmailHelper
    {
        public static bool IsValidEmail(string email)
        {
            bool isValid = false;

            Match match = Regex.Match(email, "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                isValid = true;
            }

            return isValid;
        }

        public static void Send(List<string> Address, string Subject, string Message)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SMTPEmail"]);
            foreach (var item in Address)
            {
                mailMessage.To.Add(new MailAddress(item));
            }
            mailMessage.Subject = Subject;
            mailMessage.Body = Message;
            mailMessage.IsBodyHtml = true;

            NetworkCredential _NetworkCredetial = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);

            SmtpClient client = new SmtpClient();
            client.Host = ConfigurationManager.AppSettings["SMTPHost"];
            client.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTPSSL"]);
            client.Credentials = _NetworkCredetial;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SMTPPort"].ToString()))
            {
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"].ToString());
            }

            try
            {
                client.Send(mailMessage);
            }
            catch
            {
            }
        }
    }
}
