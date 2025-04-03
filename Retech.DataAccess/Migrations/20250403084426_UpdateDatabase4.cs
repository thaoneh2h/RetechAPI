using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "E_Wallet");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "E_Wallet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "WalletStatus",
                table: "E_Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletStatus",
                table: "E_Wallet");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "E_Wallet",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "E_Wallet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
