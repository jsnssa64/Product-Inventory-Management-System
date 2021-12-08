using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InventoryItemAggregateAndVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AggregateId",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "InventoryItem");
        }
    }
}
