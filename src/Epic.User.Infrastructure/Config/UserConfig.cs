// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserConfig.cs" company="MCode">
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see https://www.gnu.org/licenses.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Infrastructure.Config
{
    using Epic.Identity.Core.Domain;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Class UserConfig.
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Epic.Identity.Core.Domain.User}</cref>
    /// </seealso>
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref>
        ///     <name>TEntity</name>
        /// </typeparamref>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Email).HasColumnName("email");
            builder.Property(c => c.Password).HasColumnName("password");
            builder.Property(c => c.LastName).HasColumnName("lastname");
            builder.Property(c => c.Name).HasColumnName("name");
        }
    }
}