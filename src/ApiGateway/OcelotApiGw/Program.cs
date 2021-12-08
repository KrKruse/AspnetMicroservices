using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, Config) =>
                {
                    // hvilken json fil der skal bruges udfra environment - og reload hvis ændring af environment 
                    Config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    // siger at programmet skal kigge i json filen under logging sectionen
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    // kan skrive logs fra debug og console vinduet 
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                });


    }
}
