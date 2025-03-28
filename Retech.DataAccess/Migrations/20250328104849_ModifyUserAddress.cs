using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAddressId",
                table: "Shipping",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_UserAddressId",
                table: "Shipping",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_UserAddress_UserAddressId",
                table: "Shipping",
                column: "UserAddressId",
                principalTable: "UserAddress",
                principalColumn: "UserAddressId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_UserAddress_UserAddressId",
                table: "Shipping");

            migrationBuilder.DropIndex(
                name: "IX_Shipping_UserAddressId",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "UserAddressId",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Product");
        }
    }
}
