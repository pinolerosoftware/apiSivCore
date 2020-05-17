using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(category => category.Description)
                .HasMaxLength(200)
                .IsRequired();
            builder.HasOne(category => category.Tenant)
                .WithMany(tenant => tenant.Categories)
                .HasForeignKey(category => category.TenantId);
        }
    }
}
