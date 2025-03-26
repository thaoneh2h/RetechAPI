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
            builder.Property(dv => dv.Location)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(dv => dv.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for CreatedAt (UTC now)

            // Relationships
            builder.HasOne(dv => dv.Product)
                   .WithMany(p => p.DeviceVerificationForm) 
                   .HasForeignKey(dv => dv.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);  

            builder.HasOne(dv => dv.User)
                   .WithMany(u => u.DeviceVerificationForm)
                   .HasForeignKey(dv => dv.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Table name
            builder.ToTable("DeviceVerificationForm");
        }
    }

}
