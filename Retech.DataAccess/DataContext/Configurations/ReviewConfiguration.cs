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

            builder.Property(p => p.Rating)
                   .HasColumnType("float")
                   .HasDefaultValue(0);

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Defaults to UTC now when the review is created

            // Relationships

            // Table name
            builder.ToTable("Review");
        }
    }
}
