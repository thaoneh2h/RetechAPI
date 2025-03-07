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
    public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            // Primary Key
            builder.HasKey(th => th.TransactionId);

            // Properties
            builder.Property(th => th.Detail)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(th => th.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(th => th.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");

            // Relationships
            builder.HasOne(th => th.Order)  // TransactionHistory -> Order
                   .WithMany(o => o.TransactionHistory)  // Order -> TransactionHistories
                   .HasForeignKey(th => th.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);  // Adjust based on business rules

            builder.HasOne(th => th.EWallet)  // TransactionHistory -> EWallet
                   .WithMany(e => e.TransactionHistory)  // EWallet -> TransactionHistories
                   .HasForeignKey(th => th.WalletId)
                   .OnDelete(DeleteBehavior.Cascade);  // Adjust based on business rules

            // Conditional relationship with Voucher
            builder.HasOne(th => th.Voucher)  // TransactionHistory -> Voucher
                   .WithMany(v => v.TransactionHistory)  // Voucher -> TransactionHistories
                   .HasForeignKey(th => th.VoucherId)
                   .IsRequired(false)  // Voucher is optional
                   .OnDelete(DeleteBehavior.SetNull);  // Set to null if Voucher is deleted

            // One-to-one relationship with Review
            builder.HasOne(th => th.Review)  // TransactionHistory -> Review
                   .WithOne(r => r.TransactionHistory)  // Review -> TransactionHistory
                   .HasForeignKey<Review>(r => r.TransactionId)  // Review has the foreign key TransactionId
                   .OnDelete(DeleteBehavior.Cascade);  // If transaction history is deleted, the review is also deleted

            // Auto-set the CreatedAt to UTC now
            builder.Property(th => th.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Table mapping
            builder.ToTable("TransactionHistory");
        }
    }
}
