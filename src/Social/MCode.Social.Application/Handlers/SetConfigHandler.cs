// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetConfigHandler.cs" company="MCode">
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

namespace MCode.Social.Application.Handlers
{
    using MCode.Social.Abstraction.Commands.Request;
    using MCode.Social.Core.Domain;
    using MCode.Social.Core.Repository;

    using MediatR;

    using Reactor.Core;

    /// <summary>
    /// The Set Config Handler.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.RequestHandler{MCode.Social.Abstraction.Commands.Request.SetConfig, Reactor.Core.IMono{MediatR.Unit}}</cref>
    /// </seealso>
    public class SetConfigHandler : RequestHandler<SetConfig, IMono<Unit>>
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IConfigRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetConfigHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public SetConfigHandler(IConfigRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The unit.</returns>
        protected override IMono<Unit> Handle(SetConfig request)
        {
            return this.repository.Save(Config.Create(request.Server)).Map(_ => Unit.Value);
        }
    }
}