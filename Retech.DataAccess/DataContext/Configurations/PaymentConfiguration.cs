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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Primary Key
            builder.HasKey(p => p.PaymentId);

            // Properties
            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");  // Ensuring precision for amount

            builder.Property(p => p.PaymentMethod)
                   .IsRequired()
                   .HasConversion<string>();  // Store as string in database (enum to string conversion)

            builder.Property(p => p.PaymentType)
                   .IsRequired()
                   .HasConversion<string>();  // Store as string in database (enum to string conversion)

            builder.Property(p => p.TransactionStatus)
                   .IsRequired()
                   .HasConversion<string>();  // Store as string in database (enum to string conversion)

            builder.Property(p => p.TransactionDate)
                   .IsRequired();  // Transaction date must be provided

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for created at timestamp

            // Relationships
            builder.HasOne(p => p.Order)
                    .WithOne(o => o.Payment)  // Each order has one payment
                    .HasForeignKey<Payment>(p => p.OrderId)  // Payment has a foreign key to Order
                    .OnDelete(DeleteBehavior.SetNull);  // Set OrderId to null if the payment is deleted

            builder.HasOne(p => p.EWallet)
                   .WithMany(e => e.Payment)  // One EWallet can have many payments
                   .HasForeignKey(p => p.WalletId)
                   .OnDelete(DeleteBehavior.Cascade);  // If the wallet is deleted, associated payments are also deleted
            // Table name
            builder.ToTable("Payment");
        }
    }
}
