using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork.Configuration
{
    public class AppOperationClaimConfiguration : IEntityTypeConfiguration<AppOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AppOperationClaim> builder)
        {
            builder.ToTable("AppOperationClaims", @"dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

        }
    }
}
