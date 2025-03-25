using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRequest_User_UserOfferId",
                table: "ExchangeRequest");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RepairHistory",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DealPrice",
                table: "ExchangeRequest",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "UserResponseId",
                table: "ExchangeRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRequest_UserResponseId",
                table: "ExchangeRequest",
                column: "UserResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRequest_User_UserOfferId",
                table: "ExchangeRequest",
                column: "UserOfferId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRequest_User_UserResponseId",
                table: "ExchangeRequest",
                column: "UserResponseId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRequest_User_UserOfferId",
                table: "ExchangeRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRequest_User_UserResponseId",
                table: "ExchangeRequest");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRequest_UserResponseId",
                table: "ExchangeRequest");

            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RepairHistory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DealPrice",
                table: "ExchangeRequest");

            migrationBuilder.DropColumn(
                name: "UserResponseId",
                table: "ExchangeRequest");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Product",
                newName: "Price");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRequest_User_UserOfferId",
                table: "ExchangeRequest",
                column: "UserOfferId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
