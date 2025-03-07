using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.DataContext.Configurations
{
    public class ThirdPartyProviderConfiguration : IEntityTypeConfiguration<ThirdPartyProvider>
    {
        public void Configure(EntityTypeBuilder<ThirdPartyProvider> builder)
        {
            // Primary Key
            builder.HasKey(tp => tp.ProviderId);

            // Properties
            builder.Property(tp => tp.ProviderName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(tp => tp.ServiceType)
                   .IsRequired()
                   .HasMaxLength(100);  // Assuming ServiceType is stored as string

            builder.Property(tp => tp.ContactInfo)
                   .HasMaxLength(200);

            builder.Property(tp => tp.Status)
                   .IsRequired()
                   .HasMaxLength(50);  // Assuming Status is stored as string

            builder.Property(tp => tp.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Ensures the date is set by the database

            // Relationships
            builder.HasMany(tp => tp.shippings)
                   .WithOne(s => s.ThirdPartyProvider)
                   .HasForeignKey(s => s.ThirdPartyProviderId)
                   .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion if shipping records exist

            builder.HasMany(tp => tp.deviceVerification)
                   .WithOne(dv => dv.ThirdPartyProvider)
                   .HasForeignKey(dv => dv.ThirdPartyProviderId)
                   .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion if device verification records exist

            // Table name
            builder.ToTable("ThirdPartyProvider");
        }
    }
}
