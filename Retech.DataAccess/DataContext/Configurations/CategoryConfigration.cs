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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primary Key
            builder.HasKey(c => c.CategoryId);

            // Properties
            builder.Property(c => c.ElectronicEquipmentType)
                   .IsRequired()
                   .HasMaxLength(100);  // Maximum length for equipment type

            builder.Property(c => c.BrandName)
                   .IsRequired()
                   .HasMaxLength(100);  // Maximum length for brand name

            // Relationships
            builder.HasMany(c => c.Product)
                   .WithOne(p => p.Category)  // One category has many products
                   .HasForeignKey(p => p.CategoryId)  // Foreign key in Product
                   .OnDelete(DeleteBehavior.Cascade);  // Delete products when the category is deleted

            // Table name
            builder.ToTable("Category");
        }
    }
}
