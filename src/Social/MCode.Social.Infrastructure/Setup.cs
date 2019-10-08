// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setup.cs" company="MCode">
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
//  Class Setup.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Infrastructure
{
    using MCode.Social.Core.Repository;
    using MCode.Social.Infrastructure.Map;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Orleans.ApplicationParts;

    /// <summary>
    /// The setup class.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The application part manager.</returns>
        public static IApplicationPartManager AddApp(this IApplicationPartManager manager)
        {
            manager.AddApplicationPart(new AssemblyPart(typeof(Setup).Assembly));
            return manager;
        }

        /// <summary>
        /// Adds the social.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The model builder.</returns>
        public static ModelBuilder AddSocial(this ModelBuilder builder)
        {
            builder.HasDefaultSchema("social");
            builder.ApplyConfiguration(new ConfigMap());
            return builder;
        }

        /// <summary>
        /// Adds the social infrastructure.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddSocialInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IConfigRepository, ConfigRepository>();
            return services;
        }
    }
}