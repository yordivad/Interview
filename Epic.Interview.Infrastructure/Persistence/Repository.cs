using System.Linq;
using Epic.Common.Domain;
using Epic.Common.Query;
using Reactor.Core;

namespace Epic.Interview.Infrastructure
{
    public class Repository<K, T> : IRepository<K, T> where T : Entity<K>
    {
        private readonly IEntitySet set;

        public Repository(IEntitySet set)
        {
            this.set = set;
        }

        public IFlux<T> Find()
        {
            return Flux.From<T>(set.Entity<T>());
        }

        public IFlux<T> Find(Specification<T> specification)
        {
            return Flux.From<T>(set.Entity<T>().Where(specification.Spec));
        }

        public IMono<T> Find(K key)
        {
            return Mono.Just(set.Entity<T>().Find(key));
        }

        public IMono<T> Save(IMono<T> value)
        {
            return value.Map(v => set.Entity<T>().Add(v).Entity);
        }

        public IMono<T> Update(K key, IMono<T> value)
        {
            return value.Map(c => set.Entity<T>().Update(c).Entity);
        }

        public IMono<T> Delete(K key)
        {
            return Find(key).Map(v => set.Entity<T>().Remove(v).Entity);
        }
    }
}