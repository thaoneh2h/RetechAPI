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
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            // Primary Key
            builder.HasKey(th => th.HistoryId);

            // Properties
            builder.Property(th => th.Detail)
                   .IsRequired()
                   .HasMaxLength(500);


            builder.Property(th => th.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");

            // Relationships
            builder.HasOne(th => th.Order)  // TransactionHistory -> Order
                   .WithMany(o => o.OrderHistory)  // Order -> TransactionHistories
                   .HasForeignKey(th => th.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);  // Adjust based on business rules

            builder.HasOne(th => th.EWallet)  // TransactionHistory -> EWallet
                   .WithMany(e => e.OrderHistory)  // EWallet -> TransactionHistories
                   .HasForeignKey(th => th.WalletId)
                   .OnDelete(DeleteBehavior.Cascade);  // Adjust based on business rules

            // Conditional relationship with Voucher
            builder.HasOne(th => th.Voucher)  // TransactionHistory -> Voucher
                   .WithMany(v => v.OrderHistory)  // Voucher -> TransactionHistories
                   .HasForeignKey(th => th.VoucherId)
                   .IsRequired(false)  // Voucher is optional
                   .OnDelete(DeleteBehavior.SetNull);  // Set to null if Voucher is deleted

            // one to many relationship with Review
            builder.HasMany(th => th.Review)  // Một OrderHistory có nhiều Review
                   .WithOne(r => r.OrderHistory)  // Một Review thuộc về một OrderHistory
                   .HasForeignKey(r => r.HistoryId)  // Review sẽ chứa khóa ngoại HistoryId
                   .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa OrderHistory, xóa luôn các review liên quan

            // Auto-set the CreatedAt to UTC now
            builder.Property(th => th.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Table mapping
            builder.ToTable("OrderHistory");
        }
    }
}
