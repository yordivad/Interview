using Epic.Interview.Core.Domain.Entities;
using Epic.Interview.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Epic.Interview.Infrastructure
{
    public class AppContext : DbContext
    {
        private IConfiguration configuration;

        public AppContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Review> Interview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
        }
    }
}