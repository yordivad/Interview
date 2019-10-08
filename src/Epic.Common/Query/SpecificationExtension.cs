// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecificationExtension.cs" company="MCode">
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
//  Class SpecificationExtension.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Common.Query
{
    /// <summary>
    /// Class SpecificationExtension.
    /// </summary>
    public static class SpecificationExtension
    {
        /// <summary>
        /// And the specified right.
        /// </summary>
        /// <typeparam name="T">The type T</typeparam>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The specification.</returns>
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        /// <summary>
        /// Or the specified right.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The Specification of T.</returns>
        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }
    }
}