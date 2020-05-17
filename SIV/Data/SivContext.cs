using Data.Entities;
using Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class SivContext : DbContext
    {
        public SivContext(DbContextOptions<SivContext> opt) : base(opt)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserRol> UserRole { get; set; }
        public DbSet<UserBranchOffice> UserBranchOffice { get; set; }
        public DbSet<BranchOffice> BranchOffice { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
