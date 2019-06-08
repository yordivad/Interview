using System.Collections.Generic;
using Epic.Common.Domain;
using Epic.Interview.Core.Domain.Value;
using Reactor.Core;

namespace Epic.Interview.Core.Domain.Entities
{
    public class Candidate : Entity<int>
    {
        public Candidate()
        {
            Reviews = new List<Review>();
        }

        public string Name { get; protected set; }

        private Email Email { get; set; }

        public Phone Phone { get; protected set; }

        public bool Active { get; protected set; }

        public ICollection<Review> Reviews { get; protected set; }

        public void AddReview(IMono<Review> review)
        {
            review.Subscribe(Reviews.Add);
        }
    }
}