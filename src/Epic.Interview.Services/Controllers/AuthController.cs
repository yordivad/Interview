// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" AuthController.cs" company="MCode Software">
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//  Contributors: Roy Gonzalez
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Services.Controllers
{
    using Epic.Identity.Application.Commands;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class AuthController.
    /// </summary>
    /// <seealso cref="Epic.Interview.Services.Controllers.ReactiveController" />
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ReactiveController
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Logins the specified credential.
        /// </summary>
        /// <param name="credential">The credential.</param>
        /// <returns>the IActionResult.</returns>
        [HttpPost]
        public IActionResult Login(Credential credential)
        {
            return this.Result(this.mediator.Send(credential));
        }
    }
}