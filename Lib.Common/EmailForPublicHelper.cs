using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Lib.Common
{
    public class EmailForPublicHelper
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

        public static bool Send(List<string> Address, string Subject, string Message, string From, string Filename, string Path)
        {

            NetworkCredential _NetworkCredetial = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);

            SmtpClient client = new SmtpClient("smtp.indo.net.id");
            client.UseDefaultCredentials = false;
            ////client.Host = ConfigurationManager.AppSettings["SMTPHost"];
            ////client.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTPSSL"]);
            ////client.Credentials = _NetworkCredetial;
            ////if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SMTPPort"].ToString()))
            //{
            //    client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"].ToString());
            //}

            var mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SMTPEmail"]);
            mailMessage.From = new MailAddress(From);
            foreach (var item in Address)
            {
                mailMessage.To.Add(new MailAddress(item));
            }

            if (!string.IsNullOrEmpty(Filename))
            {
                foreach (string file in Directory.GetFiles(Path, Filename + ".*"))
                {
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(file));
                }
            }

            //mailMessage.ReplyTo = new MailAddress(From);
            mailMessage.ReplyToList.Add(new MailAddress(From));
            mailMessage.Subject = Subject;
            mailMessage.Body = Message;
            mailMessage.IsBodyHtml = true;
            bool success = true;
            try
            {
                client.Send(mailMessage);

            }
            catch (Exception ex)
            {
                success = false;
                Console.Write("Could not send the e-mail - error: " + ex.Message);

            }

            return success;
        }
    }
}
