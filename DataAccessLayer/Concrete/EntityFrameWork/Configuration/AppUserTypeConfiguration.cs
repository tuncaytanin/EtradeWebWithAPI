using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork.Configuration
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUserType>
    {
        public void Configure(EntityTypeBuilder<AppUserType> builder)
        {
            builder.ToTable("@AppUserTypes",@"dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserTypeName).HasMaxLength(50).IsRequired();
            

            builder.HasData(new AppUserType() { Id=1,UserTypeName="System Admin"},new AppUserType() { Id=2,UserTypeName="Admin"});
        }
    }
}
