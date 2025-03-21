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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Primary Key
            builder.HasKey(n => n.NotificationId);

            // Properties
            builder.Property(n => n.Content)
                   .IsRequired()
                   .HasMaxLength(1000);  // Ensure content length is limited

            builder.Property(n => n.Status)
                   .IsRequired()
                   .HasConversion<string>();  // Store enum as string in the database

      

            builder.Property(n => n.SendDate)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default to UTC now when the notification is created

            // Relationships
            builder.HasOne(n => n.User)
                   .WithMany(u => u.Notification)  // Assuming User has many notifications
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete notifications if the user is deleted

            // Table name
            builder.ToTable("Notification");
        }
    }
}
