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
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            // Primary Key
            builder.HasKey(s => s.ShippingId);

            // Properties
            builder.Property(s => s.TrackingNumber)
                   .HasMaxLength(100);  // Max length for tracking number

            builder.Property(s => s.ShippingFee)
                   .HasColumnType("decimal(18, 2)");  // Ensure correct precision for shipping fee

            builder.Property(s => s.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Set default UTC date for creation

            // Enum configuration for ShippingStatus
            builder.Property(s => s.ShippingStatus)
                   .HasConversion<string>();  // Store enum as string in the database

            // Relationships
            builder.HasOne(s => s.Order)
                    .WithOne(o => o.Shipping)  // Order has one Shipping
                    .HasForeignKey<Shipping>(s => s.OrderId)  // Shipping contains the foreign key to Order
                    .OnDelete(DeleteBehavior.Cascade);  // Delete Shipping if the Order is deleted

            builder.HasOne(s => s.ThirdPartyProvider)
                   .WithMany(tp => tp.shippings)
                   .HasForeignKey(s => s.ThirdPartyProviderId)
                   .OnDelete(DeleteBehavior.SetNull);  // Set the provider to null if deleted, allowing shipments to stay

            // Table name
            builder.ToTable("Shipping");
        }
    }
}
