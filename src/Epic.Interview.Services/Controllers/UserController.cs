// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="MCode">
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
//  Class UserController.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Services.Controllers
{
    using Epic.Identity.Application.Commands.Request;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class UserController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ReactiveController
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The response.</returns>
        [HttpPost]
        public IActionResult CreateUser(CreateUser user)
        {
            return this.Result(this.mediator.Send(user));
        }
    }
}