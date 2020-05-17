using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfiguration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(tenant => tenant.Id);
            builder.Property(tenant => tenant.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(tenant => tenant.SocialReazon)
                .HasMaxLength(100);            
        }
    }
}
