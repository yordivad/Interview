// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="MCode">
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
//   Class UserRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Infrastructure
{
    using Epic.Data.Infrastructure;
    using Epic.Identity.Core.Domain;
    using Epic.Identity.Core.Repository;

    /// <summary>
    /// Class UserRepository.
    /// </summary>
    /// <seealso>
    ///     <cref>Epic.Data.Infrastructure.Repository{System.Int64, Epic.Identity.Core.Domain.User}</cref>
    /// </seealso>
    /// <seealso cref="Epic.Identity.Core.Repository.IUserRepository" />
    public class UserRepository : Repository<long, User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="set">The set.</param>
        public UserRepository(IEntitySet set)
            : base(set)
        {
        }
    }
}