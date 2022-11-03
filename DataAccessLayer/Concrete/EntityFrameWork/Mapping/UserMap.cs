using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameWork.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", @"dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasColumnName("Gender")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(x => x.Adress)
                .HasColumnName("Adress")
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();


            builder.Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()")
                .IsRequired();


            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar")
                .HasMaxLength(15);

            builder.Property(x => x.Token)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(x => x.TokenExpireDate)
                .HasColumnType("DateTime");

            builder.HasData(new User
            {
                FirstName="Tuncay",
                LastName="Tanin",
                Gender =true,
                Password="12345",
                DateOfBirth= Convert.ToDateTime("1987-01-01"),
                CreatedDate = DateTime.Now,
                Adress="İstanbul",
                CreatedUserId=1,
                Email ="tt@gmail.com",
                UserName="tt",
                Id=1,
                PhoneNumber="+905324751252",
                Token=String.Empty

            });
        }
    }
}
