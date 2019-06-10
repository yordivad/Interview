// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" Startup.cs" company="MCode Software">
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

namespace Epic.Interview.Services
{
    using Epic.Data.Infrastructure;
    using Epic.Identity.Application.Handlers;
    using Epic.Identity.Infrastructure;
    using Epic.Interview.Application.Handlers;
    using Epic.Interview.Infrastructure;
    using Epic.Interview.Services.Middleware;

    using MediatR;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<UnitOfWorkMiddleware>();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, AppContext>();
            services.AddCommon();
            services.AddInterview();
            services.AddUser();
            services.AddMediatR(typeof(AddReviewHandler).Assembly, typeof(CreateUserHandler).Assembly);
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Epic Interview", Version = "v1" }); });

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddDbContext<AppContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}