// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewRepository.cs" company="MCode">
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
//   Class ReviewRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Infrastructure
{
    using Epic.Data.Infrastructure;
    using Epic.Interview.Core.Domain.Entities;
    using Epic.Interview.Core.Repository;

    /// <summary>
    /// Class ReviewRepository.
    /// </summary>
    /// <seealso>
    ///     <cref>Persistence.Repository{long, Review}</cref>
    /// </seealso>
    /// <seealso cref="IReviewRepository" />
    public class ReviewRepository : Repository<long, Review>, IReviewRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewRepository"/> class.
        /// </summary>
        /// <param name="set">The set.</param>
        public ReviewRepository(IEntitySet set)
            : base(set)
        {
        }
    }
}