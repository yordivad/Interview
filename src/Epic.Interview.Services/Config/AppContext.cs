// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppContext.cs" company="MCode">
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
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Services.Config
{
    using Epic.Identity.Infrastructure;
    using Epic.Interview.Core.Domain.Entities;
    using Epic.Interview.Infrastructure;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class AppContext.
    /// </summary>
    /// <seealso cref="DbContext" />
    public class AppContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AppContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the candidate.
        /// </summary>
        /// <value>The candidate.</value>
        public DbSet<Candidate> Candidate { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>The employees.</value>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the interview.
        /// </summary>
        /// <value>The interview.</value>
        public DbSet<Review> Interview { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInterview();
            modelBuilder.AddUser();
        }
    }
}