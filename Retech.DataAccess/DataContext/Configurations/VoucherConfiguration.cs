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
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            // Primary Key
            builder.HasKey(v => v.VoucherId);

            // Properties
            builder.Property(v => v.DiscountValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.ValidTo)
                .IsRequired();


            // Relationships
            builder.HasOne(v => v.User)
                .WithMany(u => u.Voucher)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(v => v.Order)
                .WithOne(o => o.Voucher)
                .HasForeignKey<Order>(o => o.VoucherId)
                .OnDelete(DeleteBehavior.SetNull);

            // Table name
            builder.ToTable("Voucher");
        }
    }
}
