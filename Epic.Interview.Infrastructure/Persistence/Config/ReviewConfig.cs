using Epic.Interview.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epic.Interview.Infrastructure.Config
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
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