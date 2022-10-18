using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common
{
    public static class SiteSetting
    {
        public static string AppID
        {
            get
            {
                return ConfigurationManager.AppSettings["AppID"].ToString();
            }
        }

        public static string UserID
        {
            get
            {
                return ConfigurationManager.AppSettings["UserID"].ToString();
            }
        }

        public static string SiteDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteDomain"].ToString();
            }
        }
    }
}