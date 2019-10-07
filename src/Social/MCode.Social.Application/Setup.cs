// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setup.cs" company="MCode">
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>
// <summary>
//   Class Setup.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Application
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The setup class.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Adds the social application.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddSocialApp(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Setup).Assembly);
            return services;
        }
    }
}