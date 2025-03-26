using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeviceVerificationForm_ProductId",
                table: "DeviceVerificationForm");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVerificationForm_ProductId",
                table: "DeviceVerificationForm",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeviceVerificationForm_ProductId",
                table: "DeviceVerificationForm");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVerificationForm_ProductId",
                table: "DeviceVerificationForm",
                column: "ProductId",
                unique: true);
        }
    }
}
