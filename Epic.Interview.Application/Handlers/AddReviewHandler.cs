using Epic.Interview.Application.Commands;
using Epic.Interview.Core.Domain.Entities;
using Epic.Interview.Core.Repository;
using MediatR;
using Reactor.Core;

namespace Epic.Interview.Application
{
    public class AddReviewHandler : RequestHandler<ReviewRequest, IMono<Unit>>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IReviewRepository _reviewRepository;

        public AddReviewHandler(ICandidateRepository candidateRepository, IEmployeeRepository employeeRepository,
            IReviewRepository reviewRepository)
        {
            _candidateRepository = candidateRepository;
            _employeeRepository = employeeRepository;
            _reviewRepository = reviewRepository;
        }

        protected override IMono<Unit> Handle(ReviewRequest request)
        {
            var candidate = _candidateRepository.Find(request.CandidateId);
            var employee = _employeeRepository.Find(request.EmployeeId);
            var review = Review.Create(employee, candidate, request.Feedback);
            candidate.Subscribe(c => c.AddReview(review));
            return review.Map(_ => Unit.Value);
        }
    }
}