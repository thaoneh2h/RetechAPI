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
            builder.HasOne(r => r.Participant1)
                .WithMany(u => u.ParticipantId1)
                .HasForeignKey(r => r.Participant1Id)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Buyer

            builder.HasOne(r => r.Participant2)
                .WithMany(u => u.ParticipantId2)
                .HasForeignKey(r => r.Participant2Id)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Seller

            builder.HasOne(r => r.Order)
                .WithMany(p => p.Transaction)
                .HasForeignKey(r => r.OrderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Product

            builder.HasOne(r => r.ExchangeRequest)
                .WithMany(e => e.Transaction)
                .HasForeignKey(r => r.ExchangeRequestId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for E_Wallet

            // Table name
            builder.ToTable("Transaction");
        }
    }
}
