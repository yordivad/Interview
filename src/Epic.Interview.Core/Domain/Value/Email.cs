// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Email.cs" company="MCode">
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
    /// Class Email.
    /// </summary>
    /// <seealso cref="Common.Domain.ValueObject{Email}" />
    public class Email : ValueObject<Email>
    {
        /// <summary>
        /// The email
        /// </summary>
        private readonly string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        public Email(string email)
        {
            this.email = email;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.email.GetHashCode();
        }

        /// <summary>
        /// Compare two object to verify if they are equal
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>[True] if both are equal, [False] otherwise</returns>
        protected override bool IsEqual(Email other)
        {
            return this.email == other.email;
        }
    }
}