﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.DataContext.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary Key
            builder.HasKey(o => o.OrderId);

            // Properties
            builder.Property(o => o.Quantity)
                   .IsRequired();

            builder.Property(o => o.TotalPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");  // Ensure precision for total price

            builder.Property(o => o.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for created at timestamp

            // Enum Configuration
            builder.Property(o => o.OrderStatus)
                   .IsRequired()
                   .HasConversion<string>();  // Store as string in the database

            // Relationships
            builder.HasOne(o => o.Buyer)
               .WithMany(u => u.BuyerId)  
               .HasForeignKey(o => o.BuyerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Seller)
                .WithMany(u => u.SellerId)  
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Voucher)
                    .WithOne(v => v.Order)  // Voucher corresponds to one Order (if Voucher has navigation to Order)
                    .HasForeignKey<Order>(o => o.VoucherId)  // Order contains the foreign key VoucherId
                    .OnDelete(DeleteBehavior.SetNull);  // Set VoucherId to null if the voucher is deleted

            builder.HasOne(o => o.EWallet)
                   .WithMany(e => e.Order)  // EWallet can have many Orders
                   .HasForeignKey(o => o.WalletId)  // Order contains the foreign key WalletId
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of Wallet if it’s linked to an Order
            builder.HasOne(o => o.Shipping)
                   .WithOne(s => s.Order)  // Assuming one-to-one relationship with Shipping
                   .HasForeignKey<Shipping>(s => s.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete shipping if the order is deleted
            builder.HasMany(u => u.Review)  
                   .WithOne(ua => ua.Order)
                   .HasForeignKey(ua => ua.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
            // Table name
            builder.ToTable("Order");
        }
    }
}
