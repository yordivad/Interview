// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" Security.cs" company="MCode Software">
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

namespace Epic.Interview.Services.Config
{
    using System.Text;

    using Epic.Common;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Class Security.
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Adds the bearer.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="appSettingsSection">The application settings section.</param>
        /// <returns>The IServiceCollection.</returns>
        public static IServiceCollection AddBearer(
            this IServiceCollection services,
            IConfigurationSection appSettingsSection)
        {
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(
                x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(
                x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                                                          {
                                                              ValidateIssuerSigningKey = true,
                                                              IssuerSigningKey = new SymmetricSecurityKey(key),
                                                              ValidateIssuer = false,
                                                              ValidateAudience = false,
                                                          };
                    });

            return services;
        }
    }
}