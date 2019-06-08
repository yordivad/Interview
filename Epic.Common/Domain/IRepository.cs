using Epic.Common.Query;
using Reactor.Core;

namespace Epic.Common.Domain
{
    public interface IRepository<K, T>
        where T : Entity<K>
    {
        IFlux<T> Find();

        IFlux<T> Find(Specification<T> specification);

        IMono<T> Find(K key);

        IMono<T> Save(IMono<T> value);

        IMono<T> Update(K key, IMono<T> value);

        IMono<T> Delete(K key);
    }
}