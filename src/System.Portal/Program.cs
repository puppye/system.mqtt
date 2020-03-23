using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace System.Portal
{
    class Program
    {
        static async Task Main(string[] args)
        {

            IHost host = new HostBuilder()
                .ConfigureAppConfiguration((context, Configuration) =>
                {
                    Configuration.SetBasePath(Directory.GetCurrentDirectory());
                    Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    Configuration.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    //configApp.AddEnvironmentVariables(prefix: "PREFIX_");
                    Configuration.AddCommandLine(args);
                })
                .ConfigureLogging(configureLogging =>
                {
                    configureLogging.AddConsole();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
