// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetConfig.cs" company="MCode">
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
//   Class SetConfig.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Abstraction.Commands.Request
{
    using System;

    using MediatR;

    using Orleankka.Meta;

    using Reactor.Core;

    /// <summary>
    /// The Set Config Command
    /// </summary>
    /// <seealso cref="Orleankka.Meta.Command" />
    /// <seealso>
    ///     <cref>MediatR.IRequest{Reactor.Core.IMono{MediatR.Unit}}</cref>
    /// </seealso>
    [Serializable]
    public class SetConfig : Command, IRequest<IMono<Unit>>
    {
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public string Server { get; set; }
    }
}