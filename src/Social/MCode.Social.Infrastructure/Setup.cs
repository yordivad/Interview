using MCode.Social.Core.Repository;
using MCode.Social.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orleans.ApplicationParts;

namespace MCode.Social.Infrastructure
{
    public static class Setup
    {
        public static ModelBuilder AddSocial(this ModelBuilder builder)
        {
            builder.HasDefaultSchema("social");
            builder.ApplyConfiguration(new ConfigMap());
            return builder;
        }

        public static IServiceCollection AddSocialInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IConfigRepository, ConfigRepository>();
            return services;
        }

        public static IApplicationPartManager AddApp(this IApplicationPartManager manager)
        {
            manager.AddApplicationPart(new AssemblyPart(typeof(Setup).Assembly));
            return manager;
        }

    }
}