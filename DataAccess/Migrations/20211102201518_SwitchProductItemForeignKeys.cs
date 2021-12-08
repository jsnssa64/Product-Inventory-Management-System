using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SwitchProductItemForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quantity_ProductItem_ProductItemId",
                table: "Quantity");

            migrationBuilder.DropIndex(
                name: "IX_Quantity_ProductItemId",
                table: "Quantity");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "QuantityId",
                table: "ProductItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_QuantityId",
                table: "ProductItem",
                column: "QuantityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItem_Quantity_QuantityId",
                table: "ProductItem",
                column: "QuantityId",
                principalTable: "Quantity",
                principalColumn: "QuantityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItem_Quantity_QuantityId",
                table: "ProductItem");

            migrationBuilder.DropIndex(
                name: "IX_ProductItem_QuantityId",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "QuantityId",
                table: "ProductItem");

            migrationBuilder.AddColumn<int>(
                name: "ProductItemId",
                table: "Quantity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quantity_ProductItemId",
                table: "Quantity",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantity_ProductItem_ProductItemId",
                table: "Quantity",
                column: "ProductItemId",
                principalTable: "ProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
