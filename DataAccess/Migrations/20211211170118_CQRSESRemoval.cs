using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CQRSESRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AggregateId",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "InventoryItem");

            migrationBuilder.AddColumn<bool>(
                name: "Deactivated",
                table: "InventoryItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deactivated",
                table: "InventoryItem");

            migrationBuilder.AddColumn<int>(
                name: "AggregateId",
                table: "InventoryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "InventoryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
