// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Specification.cs" company="MCode">
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
//  Class Specification.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Common.Query
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Class Specification.
    /// </summary>
    public class Specification
    {
        /// <summary>
        /// Creates the specified arguments.
        /// </summary>
        /// <typeparam name="T">the specification.</typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns>The specification.</returns>
        public static T Create<T>(params object[] args)
            where T : class
        {
            return Activator.CreateInstance(typeof(T), args) as T;
        }
    }

    /// <summary>
    /// The specification class to create queries
    /// </summary>
    /// <typeparam name="T">the type of the entity</typeparam>
    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Reviewed. Suppression is OK here.")]
    public abstract class Specification<T>
    {
        /// <summary>
        /// The predicate.
        /// </summary>
        private readonly Memoization<Func<T, bool>> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Specification{T}"/> class.
        /// </summary>
        public Specification()
        {
            this.predicate = new Memoization<Func<T, bool>>();
        }

        /// <summary>
        /// Gets the spec.
        /// </summary>
        /// <value>The spec.</value>
        public abstract Expression<Func<T, bool>> Spec { get; }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is satisfied by] [the specified entity]; otherwise, <c>false</c>.</returns>
        public bool IsSatisfiedBy(T entity)
        {
            return this.predicate.Get(this.Spec.Compile).Invoke(entity);
        }
    }
}