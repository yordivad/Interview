using Epic.Common.Domain;
using MCode.Social.Core.Domain;

namespace MCode.Social.Core.Repository
{
    public interface IConfigRepository: IRepository<long, Config>
    {
    }
}