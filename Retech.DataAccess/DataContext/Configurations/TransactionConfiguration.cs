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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // Primary Key
            builder.HasKey(r => r.TransactionId);

            // Properties
            builder.Property(r => r.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(r => r.Quantity)
                .IsRequired();

            builder.Property(r => r.TransactionType)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.TransactionStatus)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            // Relationships
            builder.HasOne(r => r.Buyer)
                .WithMany(u => u.Buyer)
                .HasForeignKey(r => r.BuyerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Buyer

            builder.HasOne(r => r.Seller)
                .WithMany(u => u.Seller)
                .HasForeignKey(r => r.SellerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Seller

            builder.HasOne(r => r.Product)
                .WithMany(p => p.Transaction)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Product

            builder.HasOne(r => r.EWallet)
                .WithMany(e => e.Transaction)
                .HasForeignKey(r => r.WalletId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for E_Wallet

            // Table name
            builder.ToTable("Transaction");
        }
    }
}
