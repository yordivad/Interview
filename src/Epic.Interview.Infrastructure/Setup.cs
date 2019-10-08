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

namespace Epic.Interview.Infrastructure
{
    using Epic.Interview.Core.Repository;
    using Epic.Interview.Infrastructure.Config;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Class InfrastructureBuilder.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Adds the interview.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>the ModelBuilder.</returns>
        public static ModelBuilder AddInterview(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CandidateConfig());
            builder.ApplyConfiguration(new EmployeeConfig());
            builder.ApplyConfiguration(new ReviewConfig());
            return builder;
        }

        /// <summary>
        /// Adds the interview.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>the IServiceCollection.</returns>
        public static IServiceCollection AddInterview(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            return services;
        }
    }
}