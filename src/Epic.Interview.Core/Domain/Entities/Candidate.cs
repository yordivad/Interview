// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Candidate.cs" company="MCode">
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

namespace Epic.Interview.Core.Domain.Entities
{
    using System.Collections.Generic;

    using Epic.Common.Domain;
    using Epic.Interview.Core.Domain.Value;

    using Reactor.Core;

    /// <summary>
    /// Class Candidate.
    /// </summary>
    /// <seealso>
    ///     <cref>Common.Domain.Entity{int}</cref>
    /// </seealso>
    public class Candidate : Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Candidate"/> class.
        /// </summary>
        public Candidate()
        {
            this.Reviews = new List<Review>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Candidate"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public Phone Phone { get; protected set; }

        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>The reviews.</value>
        public ICollection<Review> Reviews { get; protected set; }

        /// <summary>
        /// Adds the review.
        /// </summary>
        /// <param name="review">The review.</param>
        public void AddReview(IMono<Review> review)
        {
            review.Subscribe(this.Reviews.Add);
        }
    }
}