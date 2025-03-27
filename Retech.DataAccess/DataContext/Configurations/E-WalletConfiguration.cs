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
    public class E_WalletConfiguration : IEntityTypeConfiguration<E_Wallet>
    {
        public void Configure(EntityTypeBuilder<E_Wallet> builder)
        {
            // Primary Key
            builder.HasKey(w => w.WalletId);

            // Properties
            builder.Property(w => w.Balance)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");  // Ensuring precision for balance

            builder.Property(w => w.Currency)
                   .IsRequired()
                   .HasMaxLength(3);  // Currency should be a 3-character code (e.g., VND, USD)

            builder.Property(w => w.Status)
                   .IsRequired()
                   .HasConversion<string>();  // Store enum as string in the database


            builder.Property(w => w.KycVerified)
                   .IsRequired();  // KYC verification status is required

            builder.Property(w => w.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");  // Default value for created date

            // Relationships
            builder.HasOne(w => w.User)
                   .WithOne(u => u.EWallet)  // Each user can have only one wallet
                   .HasForeignKey<E_Wallet>(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Delete the wallet if the user is deleted

            builder.HasMany(w => w.Payment)
                   .WithOne(p => p.EWallet)  // One wallet can have many payments
                   .HasForeignKey(p => p.WalletId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of wallet if payment exists

            builder.HasMany(w => w.Order)
                   .WithOne(o => o.EWallet)  // One wallet can have many orders
                   .HasForeignKey(o => o.WalletId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of wallet if order exists


            // Table name
            builder.ToTable("E_Wallet");
        }
    }
}
