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
                    .WithMany(o => o.Payment)  // Một đơn hàng có thể có nhiều thanh toán
                    .HasForeignKey(p => p.OrderId)  // Payment có khóa ngoại đến Order
                    .OnDelete(DeleteBehavior.Restrict);  // Nếu thanh toán bị xóa, OrderId sẽ bị set null

            builder.HasOne(p => p.EWallet)
                   .WithMany(e => e.Payment)  // Một ví điện tử có thể có nhiều thanh toán
                   .HasForeignKey(p => p.WalletId)
                   .OnDelete(DeleteBehavior.Restrict);  // Nếu ví bị xóa, các thanh toán liên quan sẽ bị xóa

            builder.HasOne(p => p.ExchangeRequest)
                   .WithMany(er => er.Payment)  // Một yêu cầu trao đổi có thể có nhiều thanh toán
                   .HasForeignKey(p => p.ExchangeRequestId)  // Payment có khóa ngoại đến ExchangeRequest
                   .OnDelete(DeleteBehavior.Restrict);  // Nếu yêu cầu trao đổi bị xóa, các thanh toán liên quan sẽ bị xóa
            builder.HasOne(p => p.UserSubscription)  // Payment liên kết với UserSubscription
                    .WithMany(us => us.Payment)  // Một UserSubscription có thể có nhiều thanh toán
                    .HasForeignKey(p => p.SubscriptionId)  // Payment có khóa ngoại đến UserSubscription
                    .OnDelete(DeleteBehavior.Restrict);  // Nếu UserSubscription bị xóa, các Payment liên quan cũng sẽ bị xóa




            // Table name
            builder.ToTable("Payment");
        }
    }
}
