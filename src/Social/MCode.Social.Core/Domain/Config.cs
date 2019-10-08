// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="MCode">
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
//  Class Config.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Core.Domain
{
    using System;

    using Epic.Common.Domain;

    using MCode.Social.Core.Validation;

    using Reactor.Core;

    /// <summary>
    /// The config entity.
    /// </summary>
    public class Config : Entity<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        private Config(string server)
        {
            this.Server = server;
        }

        /// <summary>
        /// Gets the server.
        /// </summary>
        public string Server { get; }

        /// <summary>
        /// The Create instance.
        /// </summary>
        /// <param name="server">the server name.</param>
        /// <returns>The config.</returns>
        public static IMono<Config> Create(string server)
        {
            var validator = new ConfigValidator();
            var config = new Config(server);
            var validation = validator.Validate(config);
            return validation.IsValid
                       ? Mono.Just(config)
                       : Mono.Error<Config>(new ArgumentException(string.Join(", ", validation.Errors)));
        }
    }
}