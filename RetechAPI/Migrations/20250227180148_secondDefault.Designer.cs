﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetechAPI.Models;

#nullable disable

namespace RetechAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250227180148_secondDefault")]
    partial class secondDefault
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RetechAPI.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElectronicEquipmentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("RetechAPI.Models.DeviceVerification", b =>
                {
                    b.Property<Guid>("VerificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ThirdPartyProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VerificationResult")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VerificationId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("ThirdPartyProviderId");

                    b.HasIndex("UserId");

                    b.ToTable("DeviceVerification");
                });

            modelBuilder.Entity("RetechAPI.Models.E_Wallet", b =>
                {
                    b.Property<Guid>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KycVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("EWallet");
                });

            modelBuilder.Entity("RetechAPI.Models.ExchangeRequest", b =>
                {
                    b.Property<Guid>("ExchangeRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExchangeStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OfferedProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestedProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserOfferId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExchangeRequestId");

                    b.HasIndex("OfferedProductId");

                    b.HasIndex("RequestedProductId");

                    b.HasIndex("UserOfferId");

                    b.ToTable("ExchangeRequest");
                });

            modelBuilder.Entity("RetechAPI.Models.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("RetechAPI.Models.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("RetechAPI.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EWalletWalletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderCondition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VoucherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId");

                    b.HasIndex("EWalletWalletId");

                    b.HasIndex("UserId");

                    b.HasIndex("VoucherId")
                        .IsUnique()
                        .HasFilter("[VoucherId] IS NOT NULL");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RetechAPI.Models.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("RetechAPI.Models.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("WalletId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("RetechAPI.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Evaluate")
                        .HasColumnType("real");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RetechAPI.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("RetechAPI.Models.Shipping", b =>
                {
                    b.Property<Guid>("ShippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ShippingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ShippingStatus")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ThirdPartyProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShippingId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("ThirdPartyProviderId");

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("RetechAPI.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("RetechAPI.Models.ThirdPartyProvider", b =>
                {
                    b.Property<Guid>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProviderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderId");

                    b.ToTable("ThirdPartyProvider");
                });

            modelBuilder.Entity("RetechAPI.Models.TransactionHistory", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<decimal>("AmountDecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EWalletWalletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VoucherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.HasIndex("EWalletWalletId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.HasIndex("VoucherId");

                    b.ToTable("TransactionHistory");
                });

            modelBuilder.Entity("RetechAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KycVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RetechAPI.Models.Voucher", b =>
                {
                    b.Property<Guid>("VoucherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxDiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("VoucherId");

                    b.HasIndex("UserId");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("RetechAPI.Models.DeviceVerification", b =>
                {
                    b.HasOne("RetechAPI.Models.Product", "Product")
                        .WithOne("DeviceVerification")
                        .HasForeignKey("RetechAPI.Models.DeviceVerification", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.ThirdPartyProvider", "ThirdPartyProvider")
                        .WithMany("deviceVerification")
                        .HasForeignKey("ThirdPartyProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithMany("DeviceVerification")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ThirdPartyProvider");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.E_Wallet", b =>
                {
                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithOne("EWallet")
                        .HasForeignKey("RetechAPI.Models.E_Wallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.ExchangeRequest", b =>
                {
                    b.HasOne("RetechAPI.Models.Product", "OfferedProduct")
                        .WithMany("OfferedExchange")
                        .HasForeignKey("OfferedProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.Product", "RequestedProduct")
                        .WithMany("RequestedExchange")
                        .HasForeignKey("RequestedProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.User", "UserOffer")
                        .WithMany("ExchangeRequest")
                        .HasForeignKey("UserOfferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OfferedProduct");

                    b.Navigation("RequestedProduct");

                    b.Navigation("UserOffer");
                });

            modelBuilder.Entity("RetechAPI.Models.Message", b =>
                {
                    b.HasOne("RetechAPI.Models.User", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("RetechAPI.Models.Notification", b =>
                {
                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithMany("Notification")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.Order", b =>
                {
                    b.HasOne("RetechAPI.Models.E_Wallet", "EWallet")
                        .WithMany("Order")
                        .HasForeignKey("EWalletWalletId");

                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.Voucher", "Voucher")
                        .WithOne("Order")
                        .HasForeignKey("RetechAPI.Models.Order", "VoucherId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("EWallet");

                    b.Navigation("User");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("RetechAPI.Models.OrderItem", b =>
                {
                    b.HasOne("RetechAPI.Models.Order", "Order")
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.Product", "Product")
                        .WithMany("OrderItem")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RetechAPI.Models.Payment", b =>
                {
                    b.HasOne("RetechAPI.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("RetechAPI.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.E_Wallet", "EWallet")
                        .WithMany("Payment")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EWallet");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RetechAPI.Models.Product", b =>
                {
                    b.HasOne("RetechAPI.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithMany("Product")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.Review", b =>
                {
                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithMany("Review")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.Shipping", b =>
                {
                    b.HasOne("RetechAPI.Models.Order", "Order")
                        .WithOne("Shipping")
                        .HasForeignKey("RetechAPI.Models.Shipping", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.ThirdPartyProvider", "ThirdPartyProvider")
                        .WithMany("shippings")
                        .HasForeignKey("ThirdPartyProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ThirdPartyProvider");
                });

            modelBuilder.Entity("RetechAPI.Models.ShoppingCart", b =>
                {
                    b.HasOne("RetechAPI.Models.Product", "Product")
                        .WithMany("ShoppingCart")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("RetechAPI.Models.ShoppingCart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.TransactionHistory", b =>
                {
                    b.HasOne("RetechAPI.Models.E_Wallet", "EWallet")
                        .WithMany("TransactionHistory")
                        .HasForeignKey("EWalletWalletId");

                    b.HasOne("RetechAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetechAPI.Models.Review", "Review")
                        .WithMany("TransactionHistory")
                        .HasForeignKey("ReviewId");

                    b.HasOne("RetechAPI.Models.User", null)
                        .WithMany("TransactionHistory")
                        .HasForeignKey("UserId");

                    b.HasOne("RetechAPI.Models.Voucher", "Voucher")
                        .WithMany("TransactionHistory")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EWallet");

                    b.Navigation("Order");

                    b.Navigation("Review");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("RetechAPI.Models.Voucher", b =>
                {
                    b.HasOne("RetechAPI.Models.User", "User")
                        .WithMany("Voucher")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetechAPI.Models.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("RetechAPI.Models.E_Wallet", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Payment");

                    b.Navigation("TransactionHistory");
                });

            modelBuilder.Entity("RetechAPI.Models.Order", b =>
                {
                    b.Navigation("OrderItem");

                    b.Navigation("Payment");

                    b.Navigation("Shipping");
                });

            modelBuilder.Entity("RetechAPI.Models.Product", b =>
                {
                    b.Navigation("DeviceVerification");

                    b.Navigation("OfferedExchange");

                    b.Navigation("OrderItem");

                    b.Navigation("RequestedExchange");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("RetechAPI.Models.Review", b =>
                {
                    b.Navigation("TransactionHistory");
                });

            modelBuilder.Entity("RetechAPI.Models.ThirdPartyProvider", b =>
                {
                    b.Navigation("deviceVerification");

                    b.Navigation("shippings");
                });

            modelBuilder.Entity("RetechAPI.Models.User", b =>
                {
                    b.Navigation("DeviceVerification");

                    b.Navigation("EWallet");

                    b.Navigation("ExchangeRequest");

                    b.Navigation("Notification");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("Review");

                    b.Navigation("SentMessages");

                    b.Navigation("ShoppingCart");

                    b.Navigation("TransactionHistory");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("RetechAPI.Models.Voucher", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("TransactionHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
