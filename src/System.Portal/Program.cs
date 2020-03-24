using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Auth;
using System.IO;
using System.Logging;
using System.Threading.Tasks;

namespace System.Portal
{
    class Program
    {

        private static ILogger logger;

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
                .ConfigureServices(services =>
                {
                    services.AddAuth("Data Source=app.db");
                    services.AddNLogFactory();
                })
                .Build();

            //using (var service = host.Services.GetService<ILoggerFactory>())
            //{
            //    logger = service.CreateLogger("host");
            //}

            // await host.WaitForShutdownAsync();
            await host.RunAsync();
        }
    }
}
