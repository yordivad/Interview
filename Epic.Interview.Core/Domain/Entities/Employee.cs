using System.Collections.ObjectModel;
using Epic.Common.Domain;

namespace Epic.Interview.Core.Domain.Entities
{
    public class Employee : Entity<int>
    {
        public string Name { get; set; }

        public Collection<Review> Reviews { get; set; }
    }
}