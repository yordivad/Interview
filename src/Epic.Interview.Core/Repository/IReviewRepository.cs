// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReviewRepository.cs" company="MCode">
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
// <summary>
//  Class IReviewRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Core.Repository
{
    using Epic.Common.Domain;
    using Epic.Interview.Core.Domain.Entities;

    /// <summary>
    /// Interface IReviewRepository
    /// Implements the <see>
    ///     <cref>Common.Domain.IRepository{long, Review}</cref>
    /// </see>
    /// </summary>
    /// <seealso>
    ///     <cref>Common.Domain.IRepository{long, Review}</cref>
    /// </seealso>
    public interface IReviewRepository : IRepository<long, Review>
    {
    }
}