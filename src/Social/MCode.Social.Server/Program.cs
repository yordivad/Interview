using System;
using MCode.Social.Actor;
using MCode.Social.Infrastructure;
using Orleans.Hosting;

namespace MCode.Social.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new SiloHostBuilder();

            builder.ConfigureApplicationParts(manager =>
            {
                manager.AddApp();
            });

            builder.ConfigureServices(services =>
            {
                services.AddSocialApp();
                services.AddSocialInfrastructure();
            });



            Console.WriteLine("Hello World!");
        }
    }
}