// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CredentialHandler.cs" company="MCode">
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
//   Class CredentialHandler.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Application.Handlers
{
    using System;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using BCrypt.Net;

    using Epic.Common;
    using Epic.Common.Query;
    using Epic.Identity.Application.Commands.Request;
    using Epic.Identity.Application.Commands.Response;
    using Epic.Identity.Core.Domain;
    using Epic.Identity.Core.Repository;
    using Epic.Identity.Core.Specification;

    using MediatR;

    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using Reactor.Core;

    /// <summary>
    /// Class CredentialHandler.
    /// </summary>
    /// <seealso cref="AuthenticatedUser" />
    public class CredentialHandler : RequestHandler<Credential, IMono<AuthenticatedUser>>
    {
        /// <summary>
        /// The settings
        /// </summary>
        private readonly AppSettings settings;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialHandler" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="settings">The settings.</param>
        public CredentialHandler(IUserRepository userRepository, IOptions<AppSettings> settings)
        {
            this.userRepository = userRepository;
            this.settings = settings.Value;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The authenticated user.</returns>
        protected override IMono<AuthenticatedUser> Handle(Credential request)
        {
            var spec = Specification.Create<EmailSpecification>(request.Email);
            var user = this.userRepository.Find(spec);
            return user.FlatMap(this.ToAuthenticated(request));
        }

        /// <summary>
        /// To the authenticated.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Map to the authenticated.</returns>
        private Func<User, IMono<AuthenticatedUser>> ToAuthenticated(Credential request)
        {
            return user => user is null || !BCrypt.EnhancedVerify(request.Password, user.Password)
                               ? Mono.Error<AuthenticatedUser>(
                                   new ArgumentException("the user or the password are invalid"))
                               : Mono.Just(
                                   new AuthenticatedUser(user.Name, user.LastName, user.Email, this.Token(user)));
        }

        /// <summary>
        /// Tokens the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>the token.</returns>
        private string Token(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
                                      {
                                          Subject = new ClaimsIdentity(
                                              new[]
                                                  {
                                                      new Claim(ClaimTypes.Name, user.Id.ToString()),
                                                      new Claim(ClaimTypes.GivenName, user.Name),
                                                      new Claim(ClaimTypes.Email, user.Email),
                                                      new Claim(
                                                          ClaimTypes.Expiration,
                                                          DateTime.Now.AddDays(2).ToString(CultureInfo.InvariantCulture)),
                                                  }),
                                          Expires = DateTime.UtcNow.AddDays(2),
                                          SigningCredentials = new SigningCredentials(
                                              new SymmetricSecurityKey(key),
                                              SecurityAlgorithms.HmacSha256Signature),
                                      };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}