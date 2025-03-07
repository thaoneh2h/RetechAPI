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
    public class DeviceVerificationConfiguration : IEntityTypeConfiguration<DeviceVerification>
    {
        public void Configure(EntityTypeBuilder<DeviceVerification> builder)
        {
            // Primary Key
            builder.HasKey(dv => dv.VerificationId);

            // Properties
            builder.Property(dv => dv.Status)
                   .IsRequired()
                   .HasConversion<string>();  // Store enum as string in the database

            builder.Property(dv => dv.VerificationResult)
                   .HasMaxLength(1000);  // Limit the length of the verification result

            builder.Property(dv => dv.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for CreatedAt (UTC now)

            // Relationships
            builder.HasOne(dv => dv.Product)
                    .WithOne(p => p.DeviceVerification)  // Assuming Product has one DeviceVerification
                    .HasForeignKey<DeviceVerification>(dv => dv.ProductId)  // DeviceVerification has a foreign key to Product
                     .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of Product if it’s in DeviceVerification

            builder.HasOne(dv => dv.User)
                   .WithMany(u => u.DeviceVerification)  // Assuming User can have many DeviceVerifications
                   .HasForeignKey(dv => dv.UserId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of User if it’s in DeviceVerification

            builder.HasOne(dv => dv.ThirdPartyProvider)
                   .WithMany(tp => tp.deviceVerification)  // Assuming ThirdPartyProvider can have many DeviceVerifications
                   .HasForeignKey(dv => dv.ThirdPartyProviderId)
                   .OnDelete(DeleteBehavior.SetNull);  // Set ThirdPartyProviderId to null if the provider is deleted

            // Table name
            builder.ToTable("DeviceVerification");
        }
    }
}
