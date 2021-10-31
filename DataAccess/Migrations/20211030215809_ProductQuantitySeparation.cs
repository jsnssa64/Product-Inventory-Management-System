using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ProductQuantitySeparation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Quantity_QuantityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_QuantityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Inventory",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                newName: "IX_Inventory_ProductItemId");

            migrationBuilder.AddColumn<int>(
                name: "ProductItemId",
                table: "Quantity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Quantity_ProductItemId",
                table: "Quantity",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_ProductId",
                table: "ProductItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductItem_ProductItemId",
                table: "Inventory",
                column: "ProductItemId",
                principalTable: "ProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantity_ProductItem_ProductItemId",
                table: "Quantity",
                column: "ProductItemId",
                principalTable: "ProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductItem_ProductItemId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Quantity_ProductItem_ProductItemId",
                table: "Quantity");

            migrationBuilder.DropTable(
                name: "ProductItem");

            migrationBuilder.DropIndex(
                name: "IX_Quantity_ProductItemId",
                table: "Quantity");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "Inventory",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_ProductItemId",
                table: "Inventory",
                newName: "IX_Inventory_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "QuantityId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_QuantityId",
                table: "Products",
                column: "QuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Quantity_QuantityId",
                table: "Products",
                column: "QuantityId",
                principalTable: "Quantity",
                principalColumn: "QuantityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
