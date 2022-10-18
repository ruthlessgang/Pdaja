using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Lib.Common
{
    public class CookieHelper
    {
        private const string COOKIE_PREFIX = "SALTPM_";
        public const int CookieTimeoutInDays = 1;
        
        public static void Add(string key, string value, bool nonPersistent, bool encrypt = true)
        {
            if (encrypt)
            {
                value = Encryptor.Encrypt(value);
            }
            HttpCookie Cookie = new HttpCookie(COOKIE_PREFIX + key, value);

            if (!nonPersistent)
                Cookie.Expires = DateTime.Now.AddDays(CookieTimeoutInDays);

            HttpContext.Current.Response.Cookies.Add(Cookie);
        }
        
        public static void Remove(string key)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key];
            if (Cookie != null)
            {
                Cookie.Expires = DateTime.Now.AddHours(-2);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
        }

        public static string Get(string key, bool encrypted = true)
        {
            string cookieVal = String.Empty;
            if (HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key] != null)
            {
                cookieVal = HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key].Value;

                if (encrypted)
                    cookieVal = Encryptor.Decrypt(cookieVal);
            }
            return cookieVal;
        }

        public static void RemoveAll()
        {
            HttpCookie aCookie;
            string cookieName;
            int limit = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = HttpContext.Current.Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
        }
    }
}
