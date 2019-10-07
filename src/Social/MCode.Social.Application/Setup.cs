using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MCode.Social.Actor
{
    public static class Setup
    {
        public static IServiceCollection AddSocialApp(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Setup).Assembly);
            return services;
        }
    }
}