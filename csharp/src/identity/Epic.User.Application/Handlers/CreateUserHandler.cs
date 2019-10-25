// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateUserHandler.cs" company="MCode">
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

namespace Epic.Identity.Application.Handlers
{
    using Epic.Identity.Application.Commands.Request;
    using Epic.Identity.Core.Domain;
    using Epic.Identity.Core.Repository;

    using MediatR;

    using Reactor.Core;

    /// <summary>
    /// Class CreateUserHandler.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.RequestHandler{Epic.User.Application.Commands.CreateUser, Reactor.Core.IMono{MediatR.Unit}}</cref>
    /// </seealso>
    public class CreateUserHandler : RequestHandler<CreateUser, IMono<Unit>>
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public CreateUserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the response.</returns>
        protected override IMono<Unit> Handle(CreateUser request)
        {
            var user = User.Create(
                request.Name,
                request.LastName,
                request.Email,
                request.Password,
                request.PasswordConfirm);
            return this.userRepository.Save(user).Map(_ => Unit.Value);
        }
    }
}