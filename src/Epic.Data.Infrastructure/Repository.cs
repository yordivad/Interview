// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="MCode">
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

namespace Epic.Data.Infrastructure
{
    using System.Linq;

    using Epic.Common.Domain;
    using Epic.Common.Query;

    using Reactor.Core;

    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="TK">The type of the key.</typeparam>
    /// <typeparam name="T">the type of T.</typeparam>
    /// <seealso cref="Common.Domain.IRepository{TK, T}" />
    public class Repository<TK, T> : IRepository<TK, T>
        where T : Entity<TK>
    {
        /// <summary>
        /// The set
        /// </summary>
        private readonly IEntitySet set;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TK, T}"/> class.
        /// </summary>
        /// <param name="set">The set.</param>
        public Repository(IEntitySet set)
        {
            this.set = set;
        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The mono of type T</returns>
        public IMono<T> Delete(TK key)
        {
            return this.Find(key).Map(v => this.set.Entity<T>().Remove(v).Entity);
        }

        /// <summary>
        /// Finds the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The entity.</returns>
        public IMono<T> Find(Specification<T> specification)
        {
            return Mono.Just(this.set.Entity<T>().FirstOrDefault(specification.Spec));
        }

        /// <summary>
        /// Finds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The entity.</returns>
        public IMono<T> Find(TK key)
        {
            return Mono.Just(this.set.Entity<T>().Find(key));
        }

        /// <summary>
        /// Query this instance.
        /// </summary>
        /// <returns>The flux of type T.</returns>
        public IFlux<T> Query()
        {
            return Flux.From<T>(this.set.Entity<T>());
        }

        /// <summary>
        /// Finds the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The flux of entities.</returns>
        public IFlux<T> Query(Specification<T> specification)
        {
            return Flux.From<T>(this.set.Entity<T>().Where(specification.Spec));
        }

        /// <summary>
        /// Saves the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the result.</returns>
        public IMono<T> Save(IMono<T> value)
        {
            return value.Map(v => this.set.Entity<T>().Add(v).Entity);
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>the result.</returns>
        public IMono<T> Update(TK key, IMono<T> value)
        {
            return value.Map(c => this.set.Entity<T>().Update(c).Entity);
        }
    }
}