// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailSpecification.cs" company="MCode">
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
//  Class EmailSpecification.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Core.Specification
{
    using System;
    using System.Linq.Expressions;

    using Epic.Common.Query;
    using Epic.Identity.Core.Domain;

    /// <summary>
    /// Class EmailSpecification.
    /// </summary>
    /// <seealso>
    ///     <cref>Epic.Common.Query.Specification{Epic.Identity.Core.Domain.User}</cref>
    /// </seealso>
    public class EmailSpecification : Specification<User>
    {
        /// <summary>
        /// The email
        /// </summary>
        private readonly string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSpecification"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        public EmailSpecification(string email)
        {
            this.email = email;
        }

        /// <summary>
        /// Gets the spec.
        /// </summary>
        /// <value>The spec.</value>
        public override Expression<Func<User, bool>> Spec => user => user.Email == this.email;
    }
}