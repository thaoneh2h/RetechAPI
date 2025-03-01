using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using RetechAPI.Models;
using System;

namespace RetechAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
        public DbSet<ThirdPartyProvider> ThirdPartyProvider { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ExchangeRequest> ExchangeRequest { get; set; }
        public DbSet<E_Wallet> EWallet { get; set; }
        public DbSet<DeviceVerification> DeviceVerification { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Product (One User has many Products)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(u => u.Product)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Một Category có thể chứa nhiều Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // Sản phẩm có một danh mục
                .WithMany(c => c.Product) // Một danh mục có thể chứa nhiều sản phẩm
                .HasForeignKey(p => p.CategoryId) // Khóa ngoại ở Product
                .OnDelete(DeleteBehavior.Restrict); // Nếu xóa Category, không tự động xóa các sản phẩm
            modelBuilder.Entity<UserAddress>()
                .Property(ua => ua.AddressLine1)
                .IsRequired(); // Địa chỉ phải có

            modelBuilder.Entity<UserAddress>()
                .Property(ua => ua.Ward)
                .IsRequired();

            modelBuilder.Entity<UserAddress>()
                .Property(ua => ua.District)
                .IsRequired();

            modelBuilder.Entity<UserAddress>()
                .Property(ua => ua.City)
                .IsRequired();

            modelBuilder.Entity<UserAddress>()
                .Property(ua => ua.Country)
                .HasDefaultValue("Vietnam");

            // User - ExchangeRequest (One User can offer many ExchangeRequests)
            modelBuilder.Entity<ExchangeRequest>()
                .HasOne(er => er.UserOffer)
                .WithMany(u => u.ExchangeRequest)
                .HasForeignKey(er => er.UserOfferId)
                .OnDelete(DeleteBehavior.Restrict);

            // ExchangeRequest - Product (One Product can be requested or offered in many ExchangeRequests)
            modelBuilder.Entity<ExchangeRequest>()
                .HasOne(er => er.RequestedProduct)
                .WithMany(p => p.RequestedExchange)
                .HasForeignKey(er => er.RequestedProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRequest>()
                .HasOne(er => er.OfferedProduct)
                .WithMany(p => p.OfferedExchange)
                .HasForeignKey(er => er.OfferedProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - DeviceVerification (One User can have many DeviceVerifications)
            modelBuilder.Entity<DeviceVerification>()
                .HasOne(dv => dv.User)
                .WithMany(u => u.DeviceVerification)
                .HasForeignKey(dv => dv.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product - DeviceVerification (One Product can have one DeviceVerification)
            modelBuilder.Entity<DeviceVerification>()
                .HasOne(dv => dv.Product)
                .WithOne(p => p.DeviceVerification)
                .HasForeignKey<DeviceVerification>(dv => dv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - E_Wallet (One User has one E_Wallet)
            modelBuilder.Entity<E_Wallet>()
                .HasOne(e => e.User)
                .WithOne(u => u.EWallet)
                .HasForeignKey<E_Wallet>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Order (One User can place many Orders)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Order)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order - Payment (One Order can have one Payment)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order - OrderItem (One Order can have many OrderItems)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItem)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product - OrderItem (One Product can be in many OrderItems)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItem)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Message (One User can send many Messages)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Notification (One User can receive many Notifications)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notification)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Voucher - Order (One Voucher can be applied to one Order)
            modelBuilder.Entity<Voucher>()
                .HasOne(v => v.Order)
                .WithOne(o => o.Voucher)
                .HasForeignKey<Order>(o => o.VoucherId)
                .OnDelete(DeleteBehavior.SetNull);

            // E_Wallet - Payment (One E_Wallet can have many Payments)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.EWallet)
                .WithMany(w => w.Payment)
                .HasForeignKey(p => p.WalletId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<E_Wallet>()
           .Property(e => e.Balance)
           .HasColumnType("decimal(18,2)"); // Định nghĩa độ chính xác và tỷ lệ cho Balance (18 chữ số tổng cộng và 2 chữ số sau dấu phẩy)

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Shipping>()
                .Property(s => s.ShippingFee)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TransactionHistory>()
                .Property(th => th.AmountDecimal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Voucher>()
                .Property(v => v.DiscountValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Voucher>()
                .Property(v => v.MaxDiscountValue)
                .HasColumnType("decimal(18,2)");


        }



    }

}
