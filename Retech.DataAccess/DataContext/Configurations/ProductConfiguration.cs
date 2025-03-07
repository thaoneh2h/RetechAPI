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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Primary Key
            builder.HasKey(p => p.ProductId);

            // Properties
            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(200); // Maximum length for product name

            builder.Property(p => p.Description)
                   .HasMaxLength(1000); // Maximum length for product description

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)"); // Price with precision

            builder.Property(p => p.Condition)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .IsRequired();

            builder.Property(p => p.Evaluate)
                   .HasColumnType("float")
                   .HasDefaultValue(0);  // Default rating to 0

            builder.Property(p => p.CreateDate)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default UTC time

            builder.Property(p => p.Images)
                   .HasMaxLength(5000);  // Max length for JSON string storing image URLs

            builder.Property(p => p.Stock)
                   .IsRequired();

            // Relationships
            builder.HasOne(p => p.User)
                   .WithMany(u => u.Product)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete products if the user is deleted

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Product)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of category if products exist

            builder.HasOne(p => p.DeviceVerification)
                   .WithOne(dv => dv.Product)
                   .HasForeignKey<DeviceVerification>(dv => dv.ProductId)
                   .OnDelete(DeleteBehavior.SetNull);  // Set DeviceVerification to null if product is deleted

            // Indexes
            builder.HasIndex(p => p.ProductName);  // Optional: Index for searching products by name

            // Table mapping
            builder.ToTable("Product");
        }
    }
}
