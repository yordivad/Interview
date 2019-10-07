// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="MCode">
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
//   Class IUserRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Core.Repository
{
    using Epic.Common.Domain;
    using Epic.Identity.Core.Domain;

    /// <summary>
    /// Interface IUserRepository
    /// Implements the <see>
    ///     <cref>Common.Domain.IRepository{long, User}</cref>
    /// </see>.
    /// </summary>
    /// <seealso>
    ///     <cref>Common.Domain.IRepository{long, User}</cref>
    /// </seealso>
    public interface IUserRepository : IRepository<long, User>
    {
    }
}