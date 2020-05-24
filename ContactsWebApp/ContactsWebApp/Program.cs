using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using ContactsWebApp.Data;

namespace ContactsWebApp
{
    public class Program
    {
        /**
         * Builds the web host using the specified arguments and Startup class.
         * @param args Arguments
         */
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            if (!File.Exists(Storage.FilePath))
            {
                File.WriteAllText(Storage.FilePath, "[]");
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }

            host.Run();
        }
    }
}
