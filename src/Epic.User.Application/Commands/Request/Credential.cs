// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Credential.cs" company="MCode">
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
//   Class Credential.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Application.Commands.Request
{
    using Epic.Identity.Application.Commands.Response;

    using MediatR;

    using Reactor.Core;

    /// <summary>
    /// Class Credential.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Reactor.Core.IMono{Epic.Identity.Application.Commands.AuthenticatedUser}}</cref>
    /// </seealso>
    public class Credential : IRequest<IMono<AuthenticatedUser>>
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}