using Epic.Common.Domain;
using Epic.Interview.Core.Domain.Entities;

namespace Epic.Interview.Core.Repository
{
    public interface ICandidateRepository : IRepository<int, Candidate>
    {
    }
}