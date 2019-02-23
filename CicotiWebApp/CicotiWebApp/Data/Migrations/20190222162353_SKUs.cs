using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class SKUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "SKUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOMConversionFactor",
                table: "SKUs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOM",
                table: "SKUs");

            migrationBuilder.DropColumn(
                name: "UOMConversionFactor",
                table: "SKUs");
        }
    }
}
