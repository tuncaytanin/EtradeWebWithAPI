﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Adress");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 1, 15, 33, 12, 243, DateTimeKind.Local).AddTicks(5925))
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("DateOfBirth")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Password");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FistName");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "İstanbul",
                            CreatedDate = new DateTime(2022, 11, 1, 15, 33, 12, 251, DateTimeKind.Local).AddTicks(675),
                            CreatedUserId = 1,
                            DateOfBirth = new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tt@gmail.com",
                            FirstName = "Tuncay",
                            Gender = true,
                            LastName = "Tanin",
                            Password = "12345",
                            UserName = "tt"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
