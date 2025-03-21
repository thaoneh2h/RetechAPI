using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVerification_Product_ProductId",
                table: "DeviceVerification");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVerification_User_UserId",
                table: "DeviceVerification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceVerification",
                table: "DeviceVerification");

            migrationBuilder.RenameTable(
                name: "DeviceVerification",
                newName: "DeviceVerificationForm");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceVerification_UserId",
                table: "DeviceVerificationForm",
                newName: "IX_DeviceVerificationForm_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceVerification_ProductId",
                table: "DeviceVerificationForm",
                newName: "IX_DeviceVerificationForm_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceVerificationForm",
                table: "DeviceVerificationForm",
                column: "VerificationSubmitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVerificationForm_Product_ProductId",
                table: "DeviceVerificationForm",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVerificationForm_User_UserId",
                table: "DeviceVerificationForm",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVerificationForm_Product_ProductId",
                table: "DeviceVerificationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVerificationForm_User_UserId",
                table: "DeviceVerificationForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceVerificationForm",
                table: "DeviceVerificationForm");

            migrationBuilder.RenameTable(
                name: "DeviceVerificationForm",
                newName: "DeviceVerification");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceVerificationForm_UserId",
                table: "DeviceVerification",
                newName: "IX_DeviceVerification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceVerificationForm_ProductId",
                table: "DeviceVerification",
                newName: "IX_DeviceVerification_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceVerification",
                table: "DeviceVerification",
                column: "VerificationSubmitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVerification_Product_ProductId",
                table: "DeviceVerification",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVerification_User_UserId",
                table: "DeviceVerification",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
