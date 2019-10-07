// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="MCode">
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
//   Class IRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Common.Domain
{
    using Epic.Common.Query;

    using Reactor.Core;

    /// <summary>
    /// Interface IRepository.
    /// </summary>
    /// <typeparam name="TK">The type of the key</typeparam>
    /// <typeparam name="T">The type of the entity</typeparam>
    public interface IRepository<in TK, T>
        where T : Entity<TK>
    {
        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The mono of type T</returns>
        IMono<T> Delete(TK key);

        /// <summary>
        /// Finds the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The entity.</returns>
        IMono<T> Find(Specification<T> specification);

        /// <summary>
        /// Finds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The entity.</returns>
        IMono<T> Find(TK key);

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <returns>The flux of type T.</returns>
        IFlux<T> Query();

        /// <summary>
        /// Finds the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The flux of entities.</returns>
        IFlux<T> Query(Specification<T> specification);

        /// <summary>
        /// Saves the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The entity.</returns>
        IMono<T> Save(IMono<T> value);

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>The entity.</returns>
        IMono<T> Update(TK key, IMono<T> value);
    }
}