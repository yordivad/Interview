// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrSpecification.cs" company="MCode">
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
//   Class OrSpecification.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Common.Query
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Class OrSpecification.
    /// </summary>
    /// <typeparam name="T">The type of the specification</typeparam>
    /// <seealso cref="Query.Specification{T}" />
    public class OrSpecification<T> : Specification<T>
    {
        /// <summary>
        /// The left
        /// </summary>
        private readonly Specification<T> left;

        /// <summary>
        /// The right
        /// </summary>
        private readonly Specification<T> right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrSpecification{T}"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Gets the spec.
        /// </summary>
        /// <value>The spec.</value>
        public override Expression<Func<T, bool>> Spec =>
            Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(this.left.Spec, this.right.Spec),
                this.left.Spec.Parameters.Single());
    }
}