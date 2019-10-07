// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CandidateConfig.cs" company="MCode">
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
//   Class CandidateConfig.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Infrastructure.Config
{
    using Epic.Interview.Core.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Class CandidateConfig.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Candidate}" />
    public class CandidateConfig : IEntityTypeConfiguration<Candidate>
    {
        /// <summary>
        /// Configures the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Configure(EntityTypeBuilder<Candidate> entity)
        {
            entity.HasKey(p => p.Id);
            entity.OwnsOne(p => p.Phone, phone => { phone.Property(p => p.Number).HasColumnName("phone"); });
            entity.HasMany(c => c.Reviews).WithOne();
            entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
        }
    }
}