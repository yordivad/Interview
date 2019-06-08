using Epic.Interview.Core.Domain.Entities;
using Epic.Interview.Core.Repository;

namespace Epic.Interview.Infrastructure
{
    public class EmployeeRepository : Repository<int, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IEntitySet set)
            : base(set)
        {
        }
    }
}