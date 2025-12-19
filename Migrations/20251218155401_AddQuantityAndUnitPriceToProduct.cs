using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWinFormsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityAndUnitPriceToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPurchasePrice",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitPurchasePrice",
                table: "Products");
        }
    }
}
