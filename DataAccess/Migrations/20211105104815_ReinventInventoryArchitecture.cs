using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ReinventInventoryArchitecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Products_ProductId",
                table: "InventoryItem");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_ProductId",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "WeightPerUnit",
                table: "InventoryItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "InventoryItem",
                newName: "UnitsInStock");

            migrationBuilder.RenameColumn(
                name: "ItemsPerUnit",
                table: "InventoryItem",
                newName: "ProductItemId");

            migrationBuilder.CreateTable(
                name: "ProductItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WeightPerUnit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ItemsPerUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ProductItemId",
                table: "InventoryItem",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                table: "ProductItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_ProductItem_ProductItemId",
                table: "InventoryItem",
                column: "ProductItemId",
                principalTable: "ProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_ProductItem_ProductItemId",
                table: "InventoryItem");

            migrationBuilder.DropTable(
                name: "ProductItem");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_ProductItemId",
                table: "InventoryItem");

            migrationBuilder.RenameColumn(
                name: "UnitsInStock",
                table: "InventoryItem",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "InventoryItem",
                newName: "ItemsPerUnit");

            migrationBuilder.AddColumn<decimal>(
                name: "WeightPerUnit",
                table: "InventoryItem",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryItemId = table.Column<int>(type: "int", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryItem_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "InventoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ProductId",
                table: "InventoryItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryItemId",
                table: "Inventory",
                column: "InventoryItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Products_ProductId",
                table: "InventoryItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
