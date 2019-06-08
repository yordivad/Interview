using Microsoft.EntityFrameworkCore;

namespace Epic.Interview.Infrastructure
{
    public interface IEntitySet
    {
        DbSet<T> Entity<T>() where T : class;
    }
}