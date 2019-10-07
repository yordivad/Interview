using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCode.Social.Infrastructure.Config
{
    public class ConfigMap: IEntityTypeConfiguration<Core.Domain.Config>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Config> builder)
        {
            builder.ToTable("social.config");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Server).HasColumnName("server");
        }
    }
}