using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ExchangeRequest_ExchangeRequestId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_E_Wallet_WalletId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_BuyerId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_SellerId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_BuyerId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "Transaction",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Transaction",
                newName: "Participant2Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Transaction",
                newName: "Participant1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_WalletId",
                table: "Transaction",
                newName: "IX_Transaction_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_SellerId",
                table: "Transaction",
                newName: "IX_Transaction_Participant2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_ProductId",
                table: "Transaction",
                newName: "IX_Transaction_Participant1Id");

            migrationBuilder.AddColumn<Guid>(
                name: "E_WalletWalletId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExchangeRequestId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_E_WalletWalletId",
                table: "Transaction",
                column: "E_WalletWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ExchangeRequestId",
                table: "Transaction",
                column: "ExchangeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TransactionId",
                table: "Payment",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ExchangeRequest_ExchangeRequestId",
                table: "Payment",
                column: "ExchangeRequestId",
                principalTable: "ExchangeRequest",
                principalColumn: "ExchangeRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Transaction_TransactionId",
                table: "Payment",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_E_Wallet_E_WalletWalletId",
                table: "Transaction",
                column: "E_WalletWalletId",
                principalTable: "E_Wallet",
                principalColumn: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_ExchangeRequest_ExchangeRequestId",
                table: "Transaction",
                column: "ExchangeRequestId",
                principalTable: "ExchangeRequest",
                principalColumn: "ExchangeRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Order_OrderId",
                table: "Transaction",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_Participant1Id",
                table: "Transaction",
                column: "Participant1Id",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_Participant2Id",
                table: "Transaction",
                column: "Participant2Id",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ExchangeRequest_ExchangeRequestId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Transaction_TransactionId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_E_Wallet_E_WalletWalletId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_ExchangeRequest_ExchangeRequestId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Order_OrderId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_Participant1Id",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_Participant2Id",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_E_WalletWalletId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ExchangeRequestId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Payment_TransactionId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "E_WalletWalletId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ExchangeRequestId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "Participant2Id",
                table: "Transaction",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "Participant1Id",
                table: "Transaction",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Transaction",
                newName: "WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Participant2Id",
                table: "Transaction",
                newName: "IX_Transaction_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Participant1Id",
                table: "Transaction",
                newName: "IX_Transaction_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_OrderId",
                table: "Transaction",
                newName: "IX_Transaction_WalletId");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BuyerId",
                table: "Transaction",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ExchangeRequest_ExchangeRequestId",
                table: "Payment",
                column: "ExchangeRequestId",
                principalTable: "ExchangeRequest",
                principalColumn: "ExchangeRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_E_Wallet_WalletId",
                table: "Transaction",
                column: "WalletId",
                principalTable: "E_Wallet",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_BuyerId",
                table: "Transaction",
                column: "BuyerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_SellerId",
                table: "Transaction",
                column: "SellerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
