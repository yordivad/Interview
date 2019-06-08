using System;
using Epic.Common.Domain;
using Reactor.Core;

namespace Epic.Interview.Core.Domain.Entities
{
    public class Review : Entity<long>
    {
        public Candidate Candidate { get; protected set; }

        public Employee Employee { get; protected set; }

        public DateTime Date { get; protected set; }

        public string Feedback { get; protected set; }


        public static IMono<Review> Create(IMono<Employee> employee, IMono<Candidate> candidate, string feedback)
        {
            return candidate.FlatMap(c => employee.FlatMap(e => Mono.Just(new Review
            {
                Candidate = c,
                Employee = e,
                Date = DateTime.Now,
                Feedback = feedback
            })));
        }
    }
}