using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MrLink.Domain;

namespace MrLink.Persistence.EntityTypeConfigurations
{
    public class MLinkConfiguration : IEntityTypeConfiguration<MLink>
    {
        public void Configure(EntityTypeBuilder<MLink> builder)
        {
            builder.HasKey(m => m.LinkId);
            builder.HasIndex(m => m.UserId).IsUnique();
            
        }
    }
}
