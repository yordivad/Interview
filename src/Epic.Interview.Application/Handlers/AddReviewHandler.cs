// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddReviewHandler.cs" company="MCode">
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Application.Handlers
{
    using Epic.Interview.Application.Commands;
    using Epic.Interview.Core.Domain.Entities;
    using Epic.Interview.Core.Repository;

    using MediatR;

    using Reactor.Core;

    /// <summary>
    /// Class AddReviewHandler.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.RequestHandler{ReviewRequest, IMono{Unit}}</cref>
    /// </seealso>
    public class AddReviewHandler : RequestHandler<ReviewRequest, IMono<Unit>>
    {
        /// <summary>
        /// The candidate repository.
        /// </summary>
        private readonly ICandidateRepository candidateRepository;

        /// <summary>
        /// The employee repository.
        /// </summary>
        private readonly IEmployeeRepository employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddReviewHandler"/> class.
        /// </summary>
        /// <param name="candidateRepository">The candidate repository.</param>
        /// <param name="employeeRepository">The employee repository.</param>
        public AddReviewHandler(ICandidateRepository candidateRepository, IEmployeeRepository employeeRepository)
        {
            this.candidateRepository = candidateRepository;
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The mono type.</returns>
        protected override IMono<Unit> Handle(ReviewRequest request)
        {
            var candidate = this.candidateRepository.Find(request.CandidateId);
            var employee = this.employeeRepository.Find(request.EmployeeId);
            var review = Review.Create(employee, candidate, request.Feedback);
            candidate.Subscribe(c => c.AddReview(review));
            return review.Map(_ => Unit.Value);
        }
    }
}