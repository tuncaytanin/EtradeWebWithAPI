using Core.Entites.Concrete;
using Core.Entites.Enums;
using Core.Utilities.Security.Hash.Sha512;
using Core.Utilities.Security.Token;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers", @"dbo");
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

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(x => x.Adress)
                .HasColumnName("Adress")
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.GsmNumber)
                .HasColumnName("GsmNumber")
                .HasColumnType("varchar")
                .HasMaxLength(15);

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired();
            builder.Property(x => x.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .IsRequired();

            builder.Property(x => x.ProfileImageUrl)
                .HasColumnName("ProfileImageUrl")
                .HasMaxLength(500);

            builder.Property(x =>x.CreatedDate)
                .HasColumnName("CreateDate")
                .IsRequired();

            byte[] passwordHash,passwordSalt;
            Sha512Helper.CreatePaswordHash("12345",out passwordHash, out passwordSalt);
            builder.HasData(new AppUser
            {
                Id = -1,
                FirstName ="Tuncay",
                LastName="Tanin",

                CreatedDate = DateTime.Now,
                Adress="İstanbul",
                CreatedUserId=1,
                Email ="tt@gmail.com",
                UserName="tt",
                GsmNumber =String.Empty,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                UserTypeId=(int)AppUserTypes.SystemAdmin,
                //Token=String.Empty
               RefreshToken = Guid.NewGuid()

            });
        }
    }
}
