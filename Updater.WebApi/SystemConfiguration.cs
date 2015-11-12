using System;
using System.Configuration;

namespace Updater.WebApi
{
    internal sealed class SystemConfiguration
    {
        public static string Host
        {
            get { return ConfigurationManager.AppSettings["Host"]; }
        }

        public static int RefreshTimeout
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["RefreshTimeout"]); }
        }

        public static string AppName
        {
            get { return ConfigurationManager.AppSettings["AppName"]; }
        }
    }
}