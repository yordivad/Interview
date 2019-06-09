// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" EmployeeConfig.cs" company="MCode Software">
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//  Contributors: Roy Gonzalez
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Infrastructure.Persistence.Config
{
    using Epic.Interview.Core.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Class EmployeeConfig.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Employee}" />
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// Configures the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name);
        }
    }
}