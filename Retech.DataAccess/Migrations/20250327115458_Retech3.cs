using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Retech3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Voucher",
                newName: "VoucherStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "User",
                newName: "UserStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Product",
                newName: "ProductStatus");

            migrationBuilder.RenameColumn(
                name: "TransactionStatus",
                table: "Payment",
                newName: "PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Notification",
                newName: "NotificationStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VoucherStatus",
                table: "Voucher",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "User",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ProductStatus",
                table: "Product",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "Payment",
                newName: "TransactionStatus");

            migrationBuilder.RenameColumn(
                name: "NotificationStatus",
                table: "Notification",
                newName: "Status");
        }
    }
}
