// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewRequest.cs" company="MCode">
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>
// <summary>
//   Class ReviewRequest.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Application.Commands
{
    using MediatR;

    using Reactor.Core;

    /// <summary>
    /// Class ReviewRequest.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{IMono{Unit}}</cref>
    /// </seealso>
    public class ReviewRequest : IRequest<IMono<Unit>>
    {
        /// <summary>
        /// Gets or sets the candidate identifier.
        /// </summary>
        /// <value>The candidate identifier.</value>
        public int CandidateId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the feedback.
        /// </summary>
        /// <value>The feedback.</value>
        public string Feedback { get; set; }
    }
}