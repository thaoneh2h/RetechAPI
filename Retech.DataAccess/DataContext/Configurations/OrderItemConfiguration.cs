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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Primary Key
            builder.HasKey(oi => oi.OrderItemId);

            // Properties
            builder.Property(oi => oi.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);  // Default quantity to 1 if not specified

            builder.Property(oi => oi.TotalPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");  // Ensuring precision for total price

            // Relationships
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItem)  // Assuming Order has a collection of OrderItems
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete OrderItems if the order is deleted

            builder.HasOne(oi => oi.Product)
                   .WithMany(p => p.OrderItem)  // Assuming Product has a collection of OrderItems
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of Product if it's in an OrderItem

            // Table name
            builder.ToTable("OrderItem");
        }
    }
}
