// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" Setup.cs" company="MCode Software">
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//  Contributors: Roy Gonzalez
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Infrastructure
{
    using Epic.Identity.Core.Repository;
    using Epic.Identity.Infrastructure.Config;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Class Setup.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Adds the interview.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>the ModelBuilder.</returns>
        public static ModelBuilder AddUser(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            return builder;
        }

        /// <summary>
        /// Adds the interview.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>the IServiceCollection.</returns>
        public static IServiceCollection AddUser(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}