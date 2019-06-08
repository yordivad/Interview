using Microsoft.EntityFrameworkCore;

namespace Epic.Interview.Infrastructure
{
    public class EntitySet : IEntitySet
    {
        private readonly DbContext context;

        public EntitySet(DbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Entity<T>() where T : class
        {
            return context.Set<T>();
        }
    }
}