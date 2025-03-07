using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Retech.DataAccess.DataContext.Configurations
{
    public class ExchangeRequestConfiguration : IEntityTypeConfiguration<ExchangeRequest>
    {
        public void Configure(EntityTypeBuilder<ExchangeRequest> builder)
        {
            // Primary Key
            builder.HasKey(er => er.ExchangeRequestId);

            // Properties
            builder.Property(er => er.CreatedDate)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for CreatedDate (UTC now)

            builder.Property(er => er.ExchangeStatus)
                   .IsRequired()
                   .HasConversion<string>();  // Store enum as string in the database

            // Relationships
            builder.HasOne(er => er.UserOffer)
                   .WithMany(u => u.ExchangeRequest)  // Assuming User has a collection of ExchangeRequests
                   .HasForeignKey(er => er.UserOfferId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete exchange request if the user is deleted

            builder.HasOne(er => er.RequestedProduct)
                   .WithMany(p => p.RequestedExchange)  // Assuming Product does not have a collection of ExchangeRequests
                   .HasForeignKey(er => er.RequestedProductId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of requested product if it’s in an exchange request

            builder.HasOne(er => er.OfferedProduct)
                   .WithMany(p => p.OfferedExchange)  // Assuming Product does not have a collection of ExchangeRequests
                   .HasForeignKey(er => er.OfferedProductId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of offered product if it’s in an exchange request

            // Table name
            builder.ToTable("ExchangeRequest");
        }
    }
}
