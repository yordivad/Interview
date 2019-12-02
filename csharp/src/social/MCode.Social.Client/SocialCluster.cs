using Proto;
using Proto.Cluster;
using Proto.Cluster.Consul;

namespace MCode.Social.Client
{
    public class SocialCluster: ISocialCluster
    {
        private RootContext context;
        
        public SocialCluster()
        {
            context = new RootContext();
            Cluster.Start("Social.Cluster", "127.0.0.1", 1700, new ConsulProvider(new ConsulProviderOptions()));
        }

        public void Send()
        {
            var (pid, sc) = Cluster.GetAsync("")
        }
        
    }
}