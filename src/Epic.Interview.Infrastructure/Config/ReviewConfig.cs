// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewConfig.cs" company="MCode">
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
//   Class ReviewConfig.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Infrastructure.Config
{
    using Epic.Interview.Core.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Class ReviewConfig.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Review}" />
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        /// <summary>
        /// Configures the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(p => p.Id);
            entity.HasOne(p => p.Candidate).WithMany(c => c.Reviews).HasForeignKey("CandidateId");
            entity.HasOne(p => p.Employee).WithMany(c => c.Reviews).HasForeignKey("EmployeeId");
            entity.Property(p => p.Date);
            entity.Property(p => p.Feedback);
        }
    }
}