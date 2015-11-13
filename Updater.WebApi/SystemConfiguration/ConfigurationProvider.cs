using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Updater.WebApi.SystemConfiguration
{
    internal sealed class ConfigurationProvider
    {
        public static string Host
        {
            get { return ConfigurationManager.AppSettings["Host"]; }
        }

        public static int RefreshTimeout
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["RefreshTimeout"]); }
        }

        public static List<Application> Applications
        {
            get
            {
                return (ConfigurationManager.GetSection("applications") as Applications).Items.Cast<Application>().ToList();
            }
        }
    }
}