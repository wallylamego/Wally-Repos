using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class SKUUOMConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOMConversionFactor",
                table: "SKUs");

            migrationBuilder.AddColumn<double>(
                name: "ConversionFactor",
                table: "UOM",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionFactor",
                table: "UOM");

            migrationBuilder.AddColumn<string>(
                name: "UOMConversionFactor",
                table: "SKUs",
                nullable: true);
        }
    }
}
