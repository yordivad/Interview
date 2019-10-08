// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticatedUser.cs" company="MCode">
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
//  Class AuthenticatedUser.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Application.Commands.Response
{
    /// <summary>
    /// Class AuthenticatedUser.
    /// </summary>
    public class AuthenticatedUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedUser"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        public AuthenticatedUser(string name, string lastName, string email, string token)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Token = token;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }
    }
}