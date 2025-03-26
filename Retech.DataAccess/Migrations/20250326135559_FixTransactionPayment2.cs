using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionPayment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_E_Wallet_E_WalletWalletId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_E_WalletWalletId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "E_WalletWalletId",
                table: "Transaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "E_WalletWalletId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_E_WalletWalletId",
                table: "Transaction",
                column: "E_WalletWalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_E_Wallet_E_WalletWalletId",
                table: "Transaction",
                column: "E_WalletWalletId",
                principalTable: "E_Wallet",
                principalColumn: "WalletId");
        }
    }
}
