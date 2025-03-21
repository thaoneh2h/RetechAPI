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
          
            builder.Property(pv => pv.VerificationResult)
                .HasMaxLength(1000);  // Assuming the result is a string and needs a max length

            builder.Property(pv => pv.CreateAt)
                .HasDefaultValueSql("GETUTCDATE()");  // Auto set the created date to UTC now

            // Relationships
            builder.HasOne(pv => pv.Product)
                .WithOne(p => p.ProductVerification)  // Assuming Product has a one-to-one relationship with ProductVerification
                .HasForeignKey<ProductVerification>(pv => pv.ProductId)  // ProductVerification has a foreign key to Product
                .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of Product if it's in ProductVerification

            builder.HasOne(pv => pv.User)
                .WithMany(u => u.ProductVerification)  // Assuming User can have many ProductVerifications
                .HasForeignKey(pv => pv.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of User if it's in ProductVerification

        

            // Table name
            builder.ToTable("ProductVerification");

        }
    }
}
