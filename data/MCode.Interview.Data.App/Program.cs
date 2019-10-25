using System;
using System.IO;
using System.Threading.Tasks;
using Epic.Interview.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MCode.Interview.Data.App
{
    public static class Program
    {
        public  async static Task Main(string[] args)
        {

            var builder = new HostBuilder()
                .UseEnvironment(Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ?? "Production")
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsetting.json", true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();

                })
                .ConfigureHostConfiguration(config =>
                {
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddLogging(logging =>
                    {
                        logging.AddConfiguration(context.Configuration);
                        logging.AddConsole();
                    });
                    services.AddHostedService<Migration>();
                })
                .UseContentRoot(".")
                .Build();

            await builder.RunAsync();

        }
    }
}