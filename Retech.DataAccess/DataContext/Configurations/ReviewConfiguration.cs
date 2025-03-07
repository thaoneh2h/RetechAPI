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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // Primary Key
            builder.HasKey(r => r.ReviewId);

            // Properties
            builder.Property(r => r.Comment)
                   .IsRequired()
                   .HasMaxLength(500);  // Max length for comment

            builder.Property(r => r.Rating)
                   .IsRequired()
                   .HasDefaultValue(1);  // Default to 1 if no rating is provided (adjust this as needed)

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Defaults to UTC now when the review is created

            // Relationships
            builder.HasOne(r => r.User)
                   .WithMany(u => u.Review)  // Assuming User has a collection of Reviews
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete reviews if the user is deleted

            builder.HasOne(r => r.TransactionHistory)
                   .WithOne(th => th.Review)  // One-to-one relationship
                   .HasForeignKey<TransactionHistory>(th => th.ReviewId)  // Foreign Key in TransactionHistory pointing to Review
                   .OnDelete(DeleteBehavior.SetNull);  // Set ReviewId to null if the transaction is deleted

            // Table name
            builder.ToTable("Review");
        }
    }
}
