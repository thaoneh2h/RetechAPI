using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Retech.Core.Models;
using Retech.DataAccess.DataContext.Configurations;
using System;

namespace Retech.DataAccess.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
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
        public DbSet<DeviceVerificationForm> DeviceVerificationForm { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<ProductVerification> ProductVerifications { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Bank> Bank { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply specific configurations manually for certain entities
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());
            modelBuilder.ApplyConfiguration(new UserAddressConfiguration());
            modelBuilder.ApplyConfiguration(new OrderHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new ThirdPartyProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ExchangeRequestConfiguration());
            modelBuilder.ApplyConfiguration(new E_WalletConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceVerificationFormConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductVerificationConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionPlanConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

        }



    }

}
