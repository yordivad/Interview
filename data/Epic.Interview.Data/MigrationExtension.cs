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
// <summary>
//  Class MigrationExtension.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    public static class MigrationExtension
    {
        /// <summary>
        /// Add the migration to configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>The configuration object.</returns>
        public static IConfiguration AddMigration(this IConfiguration configuration, ILogger logger)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
                if (path != null)
                {
                    using (var connection = new NpgsqlConnection(configuration.GetConnectionString("default")))
                    {
                        var evolve = new Evolve.Evolve(connection, msg => logger.LogInformation(msg))
                                         {
                                             Locations = new[]
                                                             {
                                                                 Path.Combine(path, "db/migrations"),
                                                                 Path.Combine(path, "db/datasets")
                                                             },
                                             IsEraseDisabled = false
                                         };
                        evolve.Erase();
                        evolve.Migrate();
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError("the database migration can not be executed", e);
            }

            return configuration;
        }
    }
}