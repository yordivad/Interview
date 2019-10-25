// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="MCode">
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

namespace Epic.Common.Domain
{
    using System;

    /// <summary>
    /// Class Entity.
    /// </summary>
    /// <typeparam name="TK">the type of the key.</typeparam>
    /// <seealso>
    ///     <cref>System.IEquatable{Entity{TK}}</cref>
    /// </seealso>
    public class Entity<TK> : IEquatable<Entity<TK>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TK}"/> class.
        /// </summary>
        public Entity()
            : this(default(TK))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TK}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Entity(TK id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public TK Id { get; }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="a">the a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Entity<TK> a, Entity<TK> b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="a">the a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Entity<TK> a, Entity<TK> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Entity<TK> other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return ReferenceEquals(other, this) || other.Id.Equals(this.Id);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Entity<TK>);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}