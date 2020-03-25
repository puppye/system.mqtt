using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Auth;
using System.IO;
using System.Logging;
using System.Portal.Services;
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
                    // configureLogging.AddConsole();
                })
                .ConfigureServices(services =>
                {
                    // services.AddAuth("Data Source=app.db");
                    services.AddNLogFactory();

                    services.AddHostedService<HttpServerHost>();
                    services.AddHostedService<MqttServerHost>();
                })
                .Build();

            using (var service = host.Services.GetService<ILoggerFactory>())
            {
                logger = service.CreateLogger("host");
            }
            
            logger?.LogInformation("host is starting...");

            // await host.WaitForShutdownAsync();
            await host.RunAsync();

            // await CreateMultiHostBuilder(args).Build().RunAsync();
        }

        //private static IHostBuilder CreateMultiHostBuilder(string[] args)
        //{
        //    var builder = Host.CreateDefaultBuilder(args)
        //                       .ConfigureWebHost(webBuilder =>
        //                       {
        //                           webBuilder.UseKestrel(options =>
        //                           {
        //                               // Listen on 8080 (ipv4 and ipv6)
        //                               // options.ListenLocalhost(8080);

        //                               // Listen on 8085 (ipv4 and ipv6)
        //                               options.ListenAnyIP(8085, listenOptions =>
        //                               {
        //                                   // Write logic that runs before the TLS handshake
        //                                   listenOptions.UseMqttFilter();

        //                                   // Do HTTPS
        //                                   // listenOptions.UseHttps();
        //                               });
        //                           })
        //                           .UseStartup<Startup>();
        //                       });
        //    return builder;
        //}
    }
}
