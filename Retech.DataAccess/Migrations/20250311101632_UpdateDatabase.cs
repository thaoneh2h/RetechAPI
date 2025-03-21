using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVerification_ThirdPartyProvider_ThirdPartyProviderId",
                table: "DeviceVerification");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_DeviceVerification_ThirdPartyProviderId",
                table: "DeviceVerification");

            migrationBuilder.DropColumn(
                name: "MaxDiscountValue",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ThirdPartyProvider");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "E_Wallet");

            migrationBuilder.DropColumn(
                name: "ThirdPartyProviderId",
                table: "DeviceVerification");

            migrationBuilder.DropColumn(
                name: "VerificationResult",
                table: "DeviceVerification");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ThirdPartyProvider",
                newName: "ProviderStatus");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Notification",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "DeviceVerification",
                newName: "FormStatus");

            migrationBuilder.RenameColumn(
                name: "VerificationId",
                table: "DeviceVerification",
                newName: "VerificationSubmitId");

            migrationBuilder.AddColumn<string>(
                name: "VoucherCode",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "TransactionHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RevieweeId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewerId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductVerificationId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "FeePercentage",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationDate",
                table: "DeviceVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProductVerification",
                columns: table => new
                {
                    ProductVerificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationResult = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVerification", x => x.ProductVerificationId);
                    table.ForeignKey(
                        name: "FK_ProductVerification_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVerification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_RevieweeId",
                table: "Review",
                column: "RevieweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerId",
                table: "Review",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVerification_ProductId",
                table: "ProductVerification",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVerification_UserId",
                table: "ProductVerification",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_RevieweeId",
                table: "Review",
                column: "RevieweeId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_RevieweeId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "ProductVerification");

            migrationBuilder.DropIndex(
                name: "IX_Review_RevieweeId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewerId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "VoucherCode",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "RevieweeId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ProductVerificationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FeePercentage",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "VerificationDate",
                table: "DeviceVerification");

            migrationBuilder.RenameColumn(
                name: "ProviderStatus",
                table: "ThirdPartyProvider",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "Notification",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "FormStatus",
                table: "DeviceVerification",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "VerificationSubmitId",
                table: "DeviceVerification",
                newName: "VerificationId");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxDiscountValue",
                table: "Voucher",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "ThirdPartyProvider",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "E_Wallet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ThirdPartyProviderId",
                table: "DeviceVerification",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationResult",
                table: "DeviceVerification",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVerification_ThirdPartyProviderId",
                table: "DeviceVerification",
                column: "ThirdPartyProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVerification_ThirdPartyProvider_ThirdPartyProviderId",
                table: "DeviceVerification",
                column: "ThirdPartyProviderId",
                principalTable: "ThirdPartyProvider",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
