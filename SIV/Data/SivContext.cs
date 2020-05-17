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

        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRoles { get; set; }
        public DbSet<UserBranchOffice> UserBranchOffices { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
