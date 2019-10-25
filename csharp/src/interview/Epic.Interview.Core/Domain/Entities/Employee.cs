// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Employee.cs" company="MCode">
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

namespace Epic.Interview.Core.Domain.Entities
{
    using System.Collections.ObjectModel;

    using Epic.Common.Domain;

    /// <summary>
    /// Class Employee.
    /// </summary>
    /// <seealso>
    ///     <cref>Common.Domain.Entity{int}</cref>
    /// </seealso>
    public class Employee : Entity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>The reviews.</value>
        public Collection<Review> Reviews { get; set; }
    }
}