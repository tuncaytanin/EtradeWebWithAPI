﻿using DataAccess.Concrete.EntityFrameWork.Configuration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public AppDbContext()
        {

        }

        public virtual DbSet<AppUserType> AppUserTypes { get; set; }    
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<AppOperationClaim> OperationClaims { get; set; }   
        public virtual DbSet<AppUserTypeAppOperationClaim> AppUserAppOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Data Source=TANINPC;Initial Catalog=DbEtradeWebWithAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
            Assembly assemblyConfiguration = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyConfiguration);
        }
    }
}
