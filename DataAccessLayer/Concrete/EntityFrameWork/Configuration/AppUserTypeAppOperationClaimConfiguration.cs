using Core.Entites.Enums;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork.Configuration
{
    public class AppUserTypeAppOperationClaimConfiguration : IEntityTypeConfiguration<AppUserTypeAppOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserTypeAppOperationClaim> builder)
        {
            builder.ToTable("AppUserAppOperationClaim",@"dbo");
            builder.HasKey(x => x.Id);  
            builder.Property(x=>x.OperationClaimId).IsRequired();
            builder.Property(x=>x.UserTypeId).IsRequired();
            builder.Property(x => x.Status)
              .HasColumnName("Status")
              .HasColumnType("char(4)")
              .HasMaxLength(4)
              .IsRequired();
            //builder.HasData(new AppUserTypeAppOperationClaim
            //{
            //    Id=-1,
            //    AppOperationClaimId = 1,
            //    UserTypeId = (int)AppUserTypes.Admin
            //});
        }
    }

}
