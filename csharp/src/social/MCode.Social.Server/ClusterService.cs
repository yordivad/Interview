using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Proto;
using Proto.Cluster;
using Proto.Cluster.Consul;

namespace MCode.Social.Server
{
    public class ClusterService: BackgroundService
    {
        private readonly RootContext context;

        private readonly IActorFactory actorFactory;

        public ClusterService(IActorFactory actorFactory, ILogger<ClusterService> logger)
        {
            this.context = new RootContext();
            this.actorFactory = actorFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Cluster.Start("Social.Cluster", "127.0.0.1", 1700, new ConsulProvider(new ConsulProviderOptions()));
            return Task.CompletedTask;
        }
    }
}