// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="MCode">
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

namespace Epic.Identity.Core.Domain
{
    using System;

    using Epic.Common.Domain;
    using Epic.Identity.Core.Validation;

    using Reactor.Core;

    /// <summary>
    /// Class Identity.
    /// </summary>
    public class User : Entity<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        private User(string name, string lastName, string email, string password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; protected set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; protected set; }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirm">The confirm.</param>
        /// <returns>the user.</returns>
        public static IMono<User> Create(string name, string lastName, string email, string password, string confirm)
        {
            if (password != confirm)
            {
                return Mono.Error<User>(new ArgumentException(nameof(confirm)));
            }

            var user = new User(name, lastName, email, BCrypt.Net.BCrypt.EnhancedHashPassword(password));
            var validation = new UserValidation();
            var valid = validation.Validate(user);
            return !valid.IsValid
                       ? Mono.Error<User>(new ArgumentException(string.Join(", ", valid.Errors)))
                       : Mono.Just(user);
        }
    }
}