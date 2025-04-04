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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            // Primary Key
            builder.HasKey(m => m.MessageId);

            // Properties
            builder.Property(m => m.Content)
                   .IsRequired()
                   .HasMaxLength(1000);  // Limit the length of the message content

            builder.Property(m => m.SendDate)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for send date

            // Relationships
            builder.HasOne(m => m.Sender)
                   .WithMany(u => u.SentMessages)  // User can send many messages
                   .HasForeignKey(m => m.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent delete of Sender if messages exist

            builder.HasOne(m => m.Receiver)
                   .WithMany(u => u.ReceivedMessages)  // User can receive many messages
                   .HasForeignKey(m => m.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent delete of Receiver if messages exist

            builder.HasOne(m => m.ExchangeRequest)
                  .WithMany(e => e.Messages)
                  .HasForeignKey(m => m.ExchangeRequestId);

            // Table name
            builder.ToTable("Message");
        }
    }
}
