using System;
using Microsoft.Owin.Hosting;

namespace Updater.WebApi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(SystemConfiguration.Host))
            {
                Console.ReadLine();
            }
        }
    }
}