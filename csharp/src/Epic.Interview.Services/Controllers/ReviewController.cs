// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewController.cs" company="MCode">
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

namespace Epic.Interview.Services.Controllers
{
    using System.Threading.Tasks;

    using Epic.Interview.Application.Commands;

    using MediatR;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Reactor.Core;

    /// <summary>
    /// Class ReviewController.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task of the response.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IMono<Unit>> Post([FromBody] ReviewRequest request)
        {
            return await this.mediator.Send(request);
        }
    }
}