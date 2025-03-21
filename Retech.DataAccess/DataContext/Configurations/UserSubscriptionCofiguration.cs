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
    public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            // Properties
            builder.Property(c => c.SubscriptionId)
                .IsRequired();  // Đảm bảo SubscriptionId là bắt buộc
            builder.Property(c => c.UserId)
                .IsRequired();  // Đảm bảo UserId là bắt buộc
            builder.Property(c => c.PlanId)
                .IsRequired();  // Đảm bảo PlanId là bắt buộc
            builder.Property(c => c.RemainingPost)
                .IsRequired()   // Đảm bảo RemainingPost là bắt buộc
                .HasDefaultValue(0);  // Giá trị mặc định là 0
            builder.Property(c => c.IsActive)
                .IsRequired()   // Đảm bảo IsActive là bắt buộc
                .HasDefaultValue(false);  // Giá trị mặc định là false

            // Relationships
            builder.HasOne(c => c.User)
                   .WithOne(u => u.UserSubscription)  // Một User có thể có một UserSubscription
                   .HasForeignKey<UserSubscription>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Nếu User bị xóa thì UserSubscription cũng bị xóa

            builder.HasOne(c => c.SubscriptionPlan)
                .WithMany(sp => sp.UserSubscription)  // Một SubscriptionPlan có thể có nhiều UserSubscription
                .HasForeignKey(c => c.PlanId)
                .OnDelete(DeleteBehavior.Restrict);  // Không xóa UserSubscription nếu SubscriptionPlan bị xóa


            // Table name
            builder.ToTable("UserSubscription");
        }
    }
}
