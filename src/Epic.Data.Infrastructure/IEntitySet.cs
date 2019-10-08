// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntitySet.cs" company="MCode">
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
//  Class IEntitySet.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Data.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Interface IEntitySet.
    /// </summary>
    public interface IEntitySet
    {
        /// <summary>
        /// Entities this instance.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>The set of the entity.</returns>
        DbSet<T> Entity<T>()
            where T : class;
    }
}