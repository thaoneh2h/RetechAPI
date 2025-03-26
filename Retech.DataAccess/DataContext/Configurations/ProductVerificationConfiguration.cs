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
    public class ProductVerificationConfiguration : IEntityTypeConfiguration<ProductVerification>
    {
        public void Configure(EntityTypeBuilder<ProductVerification> builder)
        {
            // Primary Key
            builder.HasKey(pv => pv.ProductVerificationId);
            // Properties

            builder.Property(p => p.VerificationResult)
                   .HasColumnType("float")
                   .HasDefaultValue(0);
            builder.Property(p => p.SuggestPrice)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");
            builder.Property(pv => pv.CreateAt)
                .HasDefaultValueSql("GETUTCDATE()");  // Auto set the created date to UTC now

            // Relationships

            builder.HasOne(dv => dv.Product)
                .WithMany(p => p.ProductVerification)
                .HasForeignKey(dv => dv.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pv => pv.User)
                .WithMany(u => u.ProductVerification)  // Assuming User can have many ProductVerifications
                .HasForeignKey(pv => pv.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of User if it's in ProductVerification

        

            // Table name
            builder.ToTable("ProductVerification");

        }
    }
}
