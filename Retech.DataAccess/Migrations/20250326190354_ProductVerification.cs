using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductVerification_ProductId",
                table: "ProductVerification");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVerification_ProductId",
                table: "ProductVerification",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductVerification_ProductId",
                table: "ProductVerification");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVerification_ProductId",
                table: "ProductVerification",
                column: "ProductId",
                unique: true);
        }
    }
}
