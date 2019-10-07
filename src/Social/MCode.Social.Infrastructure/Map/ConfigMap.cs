// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigMap.cs" company="MCode">
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
//   Class ConfigMap.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Infrastructure.Map
{
    using MCode.Social.Core.Domain;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The config map.
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{MCode.Social.Core.Domain.Config}</cref>
    /// </seealso>
    public class ConfigMap : IEntityTypeConfiguration<Config>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref>
        ///     <name>TEntity</name>
        /// </typeparamref>
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("social.config");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Server).HasColumnName("server");
        }
    }
}