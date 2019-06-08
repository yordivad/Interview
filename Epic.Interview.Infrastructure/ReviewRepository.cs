using Epic.Interview.Core.Domain.Entities;
using Epic.Interview.Core.Repository;

namespace Epic.Interview.Infrastructure
{
    public class ReviewRepository : Repository<long, Review>, IReviewRepository
    {
        public ReviewRepository(IEntitySet set) : base(set)
        {
        }
    }
}