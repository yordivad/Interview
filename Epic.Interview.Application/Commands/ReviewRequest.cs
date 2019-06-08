using MediatR;
using Reactor.Core;

namespace Epic.Interview.Application.Commands
{
    public class ReviewRequest : IRequest<IMono<Unit>>
    {
        public int CandidateId { get; set; }

        public int EmployeeId { get; set; }

        public string Feedback { get; set; }
    }
}