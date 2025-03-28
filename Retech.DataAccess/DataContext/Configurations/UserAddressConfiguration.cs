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
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            // Primary Key
            builder.HasKey(ua => ua.UserAddressId);

            // Properties
            builder.Property(ua => ua.AddressLine)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ua => ua.Ward)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ua => ua.District)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ua => ua.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ua => ua.Country)
                .IsRequired()
                .HasDefaultValue("Vietnam")
                .HasMaxLength(100);


            builder.Property(ua => ua.IsPrimary)
                .IsRequired();

            // Relationships
            builder.HasOne(ua => ua.User)
                   .WithMany(u => u.UserAddresses)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Consider the business logic; Cascade if deleting User should also delete addresses
            builder.HasMany(ua => ua.Shipping)
                   .WithOne(s => s.UserAddress)
                   .HasForeignKey(s => s.UserAddressId)  // Shipping chứa khóa ngoại trỏ đến UserAddress
                   .OnDelete(DeleteBehavior.Restrict);

            // Table name
            builder.ToTable("UserAddress");
        }
    }
}
