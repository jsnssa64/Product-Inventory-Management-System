using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ConvertProductItemToInventoryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductItem_ProductItemId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "ProductItem");

            migrationBuilder.DropTable(
                name: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "Inventory",
                newName: "InventoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_ProductItemId",
                table: "Inventory",
                newName: "IX_Inventory_InventoryItemId");

            migrationBuilder.CreateTable(
                name: "InventoryItem",
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
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ProductId",
                table: "InventoryItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_InventoryItem_InventoryItemId",
                table: "Inventory",
                column: "InventoryItemId",
                principalTable: "InventoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_InventoryItem_InventoryItemId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.RenameColumn(
                name: "InventoryItemId",
                table: "Inventory",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_InventoryItemId",
                table: "Inventory",
                newName: "IX_Inventory_ProductItemId");

            migrationBuilder.CreateTable(
                name: "Quantity",
                columns: table => new
                {
                    QuantityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsPerUnit = table.Column<int>(type: "int", nullable: false),
                    WeightPerUnit = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantity", x => x.QuantityId);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuantityId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_ProductItem_Quantity_QuantityId",
                        column: x => x.QuantityId,
                        principalTable: "Quantity",
                        principalColumn: "QuantityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                table: "ProductItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_QuantityId",
                table: "ProductItem",
                column: "QuantityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductItem_ProductItemId",
                table: "Inventory",
                column: "ProductItemId",
                principalTable: "ProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
