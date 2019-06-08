using Epic.Interview.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epic.Interview.Infrastructure.Config
{
    public class CandidateConfig : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> entity)
        {
            entity.HasKey(p => p.Id);
            entity.OwnsOne(p => p.Phone, phone => { phone.Property(p => p.Number).HasColumnName("phone"); });
            entity.HasMany(c => c.Reviews).WithOne();
            entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
        }
    }
}