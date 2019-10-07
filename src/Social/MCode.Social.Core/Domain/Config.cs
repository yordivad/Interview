

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
        private Config(string server)
        {
            Server = server;
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