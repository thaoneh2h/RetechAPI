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
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            // Primary Key
            builder.HasKey(sc => sc.CartId);

            // Properties
            builder.Property(sc => sc.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);  // Default to 1 if not specified

            // Relationships
            builder.HasOne(sc => sc.User)
                    .WithOne(u => u.ShoppingCart)  // Assuming User has one ShoppingCart
                    .HasForeignKey<ShoppingCart>(sc => sc.UserId)
                    .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the User is deleted

            builder.HasOne(sc => sc.Product)
                    .WithMany(p => p.ShoppingCart)  // Product has many ShoppingCarts
                    .HasForeignKey(sc => sc.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);  // Prevent delete of product if it's in a shopping cart

            // Unique constraint: A user should only have one entry for each product in the cart.
            builder.HasIndex(sc => new { sc.UserId, sc.ProductId })
                   .IsUnique();  // Ensures a unique combination of UserId and ProductId

            // Table name
            builder.ToTable("ShoppingCart");
        }
    }
}
