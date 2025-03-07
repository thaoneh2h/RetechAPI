using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retech.Core.Models;

namespace Retech.DataAccess.DataContext.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(u => u.UserId);

            // Properties
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.Address)
                .HasMaxLength(255);

            builder.Property(u => u.Gender)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(u => u.ProfilePicture)
                .HasMaxLength(255);

            builder.Property(u => u.RegistrationDate)
                .IsRequired();

            builder.Property(u => u.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Rating)
                .HasColumnType("decimal(5,2)");

            builder.Property(u => u.KycVerified)
                .HasDefaultValue(false);

            // Enum configurations (if applicable)
            builder.Property(u => u.UserRole)
                .IsRequired()
                .HasMaxLength(50);

            // Relationships (One-to-Many relationships)
            builder.HasMany(u => u.Order)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Review)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.SentMessages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ReceivedMessages)
                .WithOne(m => m.Receiver)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.EWallet)
                .WithOne(e => e.User)
                .HasForeignKey<E_Wallet>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.ShoppingCart)
                .WithOne(s => s.User)
                .HasForeignKey<ShoppingCart>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Product)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ExchangeRequest)
                .WithOne(e => e.UserOffer)
                .HasForeignKey(e => e.UserOfferId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Notification)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.Voucher)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.DeviceVerification)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.UserAddresses)  // Assuming User class has a collection property UserAddresses
                   .WithOne(ua => ua.User)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Table name
            builder.ToTable("User");

        }
    }
}
