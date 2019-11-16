using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Epic.Interview.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Elasticsearch;

namespace MCode.Interview.Data.App
{
    /// <summary>
    /// The program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The Main method.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The task.</returns>
        public static async Task Main(string[] args)
        {
            var config = SetupConfiguration();
            var provider = SetupProvider(config);
            var service = provider.GetService<IHostedService>();
            await service.StartAsync( new CancellationToken());
        }

        private static ServiceProvider SetupProvider(IConfiguration config)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IHostedService, Migration>();
            services.AddSingleton(config);
            services.AddSingleton<IHostingEnvironment>(new HostingEnvironment
            {
                ApplicationName = config[HostDefaults.ApplicationKey],
                EnvironmentName = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ??
                                  EnvironmentName.Development,
            }).AddLogging(logging =>
            {
                logging.AddSerilog(SetupLogger(config).CreateLogger());
                logging.AddConfiguration(config);
                logging.AddConsole();
            });
            var provider = services.BuildServiceProvider();
            return provider;
        }

        private static LoggerConfiguration SetupLogger(IConfiguration config)
        {
            var loggerConfiguration = new LoggerConfiguration();

            loggerConfiguration.MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console(new CompactJsonFormatter())
                .WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(config.GetValue<string>("ELASTIC:URL")))
                    {
                        ModifyConnectionSettings = x => x.BasicAuthentication(
                            config.GetValue<string>("ELASTIC:USER"),
                            config.GetValue<string>("ELASTIC:PASSWORD")),
                    });
            return loggerConfiguration;
        }

        private static IConfigurationRoot SetupConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsetting.json", true);
            configurationBuilder.AddEnvironmentVariables();

            var iniFile = $"{Environment.GetEnvironmentVariable("HOME")}/settings.ini";
            if (File.Exists(iniFile))
            {
                configurationBuilder.AddIniFile(iniFile);
            }

            var config = configurationBuilder.Build();
            return config;
        }
    }
}