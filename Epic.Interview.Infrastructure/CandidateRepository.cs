using Epic.Interview.Core.Domain.Entities;
using Epic.Interview.Core.Repository;

namespace Epic.Interview.Infrastructure
{
    public class CandidateRepository : Repository<int, Candidate>, ICandidateRepository
    {
        public CandidateRepository(IEntitySet set) : base(set)
        {
        }
    }
}