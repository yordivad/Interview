// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MCode">
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;

namespace Epic.Interview.Services
{
    using System;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>The IWebHostBuilder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)

                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Environment.CurrentDirectory);
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddJsonFile(
                        $"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                        optional: true);
                    config.AddEnvironmentVariables();
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        config.AddUserSecrets<Startup>();
                    }
                })
                .UseSerilog((context, config) =>
                {
                    try
                    {
                        var configuration = context.Configuration;
                        config.MinimumLevel.Information()
                            .Enrich.FromLogContext()
                            .WriteTo.Console(new CompactJsonFormatter())
                            .WriteTo.Elasticsearch(
                                new ElasticsearchSinkOptions(new Uri(configuration.GetValue<string>("ELASTIC:URL")))
                                {
                                    ModifyConnectionSettings = x => x.BasicAuthentication(
                                        configuration.GetValue<string>("ELASTIC:USER"),
                                        configuration.GetValue<string>("ELASTIC:PASSWORD")),
                                });
                    }
                    catch (Exception e)
                    {
                        var configuration = context.Configuration;
                        throw new Exception(configuration.GetValue<string>("ELASTIC:URL"), e);
                    }
                }).UseStartup<Startup>();
        }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}