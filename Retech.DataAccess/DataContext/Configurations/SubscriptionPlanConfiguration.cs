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
    public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            // Primary Key
            builder.HasKey(c => c.PlanId);
            // Properties
            builder.Property(c => c.PlanName)
                .IsRequired()  // Đảm bảo PlanName là bắt buộc
                .HasMaxLength(100);  // Đặt độ dài tối đa cho tên kế hoạch

            builder.Property(c => c.price)
                .IsRequired()  // Đảm bảo Price là bắt buộc
                .HasColumnType("decimal(18,2)");  // Định dạng cho price là decimal

            builder.Property(c => c.PlanDescription)
                .IsRequired()  // Đảm bảo PlanDescription là bắt buộc
                .HasMaxLength(500);  // Đặt độ dài tối đa cho mô tả kế hoạch

            builder.Property(c => c.Benefit)
                .HasMaxLength(500);  // Đặt độ dài tối đa cho lợi ích

            // Relationships
            builder.HasMany(c => c.UserSubscription)
                .WithOne(us => us.SubscriptionPlan)  // Một kế hoạch có thể có nhiều người dùng đăng ký
                .HasForeignKey(us => us.PlanId)  // Mối quan hệ khóa ngoại với PlanId trong UserSubscription
                .OnDelete(DeleteBehavior.Restrict);  // Không xóa UserSubscription nếu SubscriptionPlan bị xóa


            // Table name
            builder.ToTable("SubscriptionPlan");
        }
    }
}
