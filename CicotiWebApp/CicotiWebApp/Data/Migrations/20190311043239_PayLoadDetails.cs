using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class PayLoadDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PayloadCubicMetres",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PayloadHeight",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PayloadLength",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PayloadWidth",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayloadCubicMetres",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PayloadHeight",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PayloadLength",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PayloadWidth",
                table: "Vehicles");
        }
    }
}
