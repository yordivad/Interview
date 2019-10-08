// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigActor.cs" company="MCode">
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

namespace MCode.Social.Application
{
    using MCode.Social.Abstraction.Abstract;
    using MCode.Social.Abstraction.Commands.Request;

    using MediatR;

    using Orleankka;

    /// <summary>
    /// The config actor
    /// </summary>
    /// <seealso cref="Orleankka.DispatchActorGrain" />
    /// <seealso cref="MCode.Social.Abstraction.Abstract.IConfigActor" />
    public class ConfigActor : DispatchActorGrain, IConfigActor
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigActor"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ConfigActor(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Handles the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void Handle(SetConfig config)
        {
            this.mediator.Send(config);
        }
    }
}