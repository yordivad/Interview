// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Review.cs" company="MCode">
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
//   Class Review.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Core.Domain.Entities
{
    using System;

    using Epic.Common.Domain;

    using Reactor.Core;

    /// <summary>
    /// Class Review.
    /// </summary>
    /// <seealso>
    ///     <cref>Common.Domain.Entity{long}</cref>
    /// </seealso>
    public class Review : Entity<long>
    {
        /// <summary>
        /// Gets or sets the candidate.
        /// </summary>
        /// <value>The candidate.</value>
        public Candidate Candidate { get; protected set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; protected set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public Employee Employee { get; protected set; }

        /// <summary>
        /// Gets or sets the feedback.
        /// </summary>
        /// <value>The feedback.</value>
        public string Feedback { get; protected set; }

        /// <summary>
        /// Creates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="candidate">The candidate.</param>
        /// <param name="feedback">The feedback.</param>
        /// <returns>The review.</returns>
        public static IMono<Review> Create(IMono<Employee> employee, IMono<Candidate> candidate, string feedback)
        {
            return candidate.FlatMap(
                c => employee.FlatMap(
                    e => Mono.Just(
                        new Review { Candidate = c, Employee = e, Date = DateTime.Now, Feedback = feedback })));
        }
    }
}