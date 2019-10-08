// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="MCode">
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
//  Class UserContext.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Features.Context
{
    using Epic.Identity.Application.Commands.Request;
    using Epic.Identity.Core.Repository;

    using MediatR;

    using Reactor.Core;

    /// <summary>
    /// The user context.
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public IRequestHandler<CreateUser, IMono<Unit>> Command { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public IUserRepository Repository { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserContext"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public CreateUser User { get; set; }
    }
}