// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MigrationExtension.cs" company="MCode">
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

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Epic.Interview.Data
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Npgsql;

    /// <summary>
    ///  The extension class to add the migrations of the Database automatically.
    /// </summary>
    public class Migration : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;
        private readonly IHostingEnvironment environment;

        /// <summary>
        /// The migration constructor.
        /// </summary>
        /// <param name="configuration">the configuration.</param>
        /// <param name="logger">the logger.</param>
        /// <param name="environment">the enviroment.</param>
        public Migration(IConfiguration configuration, ILogger<Migration> logger, IHostingEnvironment environment)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.environment = environment;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path));
                }
                Migrate(path);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                this.logger.LogError($"Migration Error: {e.Message} {e.StackTrace} {e.Source}");
                return Task.FromException(e);
            }
        }

   


        private void Migrate(string path)
        {
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("default"));
            var evolve = new Evolve.Evolve(connection, msg => logger.LogInformation(msg))
            {
                Locations = new[]
                {
                    Path.Combine(path, "db/migrations"),
                    Path.Combine(path, "db/datasets")
                },
                    
                IsEraseDisabled = this.environment.IsProduction()
            };

            if (this.environment.IsDevelopment())
            {
                evolve.Erase();    
            }
                
            evolve.Migrate();
        }
    }
}