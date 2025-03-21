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
    public class DeviceVerificationFormConfiguration : IEntityTypeConfiguration<DeviceVerificationForm>
    {
        public void Configure(EntityTypeBuilder<DeviceVerificationForm> builder)
        {
            // Primary Key
            builder.HasKey(dv => dv.VerificationSubmitId);

            // Properties
            builder.Property(dv => dv.FormStatus)
                   .IsRequired()
                   .HasConversion<string>();  // Store enum as string in the database

           

            builder.Property(dv => dv.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for CreatedAt (UTC now)

            // Relationships
            builder.HasOne(dv => dv.Product)
                    .WithOne(p => p.DeviceVerificationForm)  // Assuming Product has one DeviceVerification
                    .HasForeignKey<DeviceVerificationForm>(dv => dv.ProductId)  // DeviceVerification has a foreign key to Product
                     .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of Product if it’s in DeviceVerification

            builder.HasOne(dv => dv.User)
                   .WithMany(u => u.DeviceVerificationForm)  // Assuming User can have many DeviceVerifications
                   .HasForeignKey(dv => dv.UserId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of User if it’s in DeviceVerification

            // Table name
            builder.ToTable("DeviceVerificationForm");
        }
    }
}
