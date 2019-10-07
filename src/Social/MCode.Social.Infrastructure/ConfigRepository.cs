using Epic.Data.Infrastructure;

using MCode.Social.Core.Repository;

namespace MCode.Social.Infrastructure
{
    public class ConfigRepository : Repository<long, Core.Domain.Config>, IConfigRepository
    {
        public ConfigRepository(IEntitySet set)
            : base(set)
        {
        }
    }
}