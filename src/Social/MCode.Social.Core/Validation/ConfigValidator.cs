// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigValidator.cs" company="MCode">
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
//   Class ConfigValidator.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Core.Validation
{
    using FluentValidation;

    using MCode.Social.Core.Domain;

    /// <summary>
    /// The config validator.
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{MCode.Social.Core.Domain.Config}</cref>
    /// </seealso>
    public class ConfigValidator : AbstractValidator<Config>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigValidator"/> class.
        /// </summary>
        public ConfigValidator()
        {
            this.RuleFor(c => c.Server).NotEmpty().NotNull();
        }
    }
}