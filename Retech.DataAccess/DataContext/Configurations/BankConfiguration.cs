using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retech.Core.Models;

namespace Retech.DataAccess.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            // Primary key
            builder.HasKey(b => b.BankId);

            // Foreign key relationship with User
            builder.HasOne(b => b.User)
                .WithMany(u => u.Bank)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);  

            // Foreign key relationship with Payment
            builder.HasMany(b => b.Payment)
                .WithOne(p => p.Bank)
                .HasForeignKey(p => p.BankId)
                .OnDelete(DeleteBehavior.SetNull); // Assuming if the bank is deleted, payments should not be deleted but have a null Bank reference

            builder.Property(b => b.AccountNumber)
                .IsRequired()
                .HasMaxLength(50);  // Adjust length if needed

            builder.Property(b => b.Status)
                .IsRequired()
                .HasMaxLength(50);  // Adjust length if needed

            builder.Property(b => b.Balance)
                .HasColumnType("decimal(15,2)");

            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


            // Table mapping
            builder.ToTable("Bank");
        }
    }
}
