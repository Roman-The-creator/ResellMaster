using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWinFormsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleCosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profit",
                table: "Sales",
                newName: "ViewsCost");

            migrationBuilder.AddColumn<decimal>(
                name: "AdCost",
                table: "Sales",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PlatformFeePercent",
                table: "Sales",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdCost",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PlatformFeePercent",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "ViewsCost",
                table: "Sales",
                newName: "Profit");
        }
    }
}
