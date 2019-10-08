// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Phone.cs" company="MCode">
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

namespace Epic.Interview.Core.Domain.Value
{
    using Epic.Common.Domain;

    /// <summary>
    /// Class Phone.
    /// </summary>
    /// <seealso cref="Common.Domain.ValueObject{Phone}" />
    public class Phone : ValueObject<Phone>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Phone"/> class.
        /// </summary>
        /// <param name="number">The number.</param>
        public Phone(string number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get; }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        /// <summary>
        /// Compare two object to verify if they are equal
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>[True] if both are equal, [False] otherwise</returns>
        protected override bool IsEqual(Phone other)
        {
            return this.Number.Equals(other.Number);
        }
    }
}