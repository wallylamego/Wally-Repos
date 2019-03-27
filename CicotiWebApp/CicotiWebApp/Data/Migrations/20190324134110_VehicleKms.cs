using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class VehicleKms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelPrice",
                columns: table => new
                {
                    FuelPriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PriceExclVat = table.Column<double>(nullable: false),
                    PriceInclVat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrice", x => x.FuelPriceID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleKms",
                columns: table => new
                {
                    VehicleKmID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TravelDate = table.Column<DateTime>(nullable: false),
                    StartKm = table.Column<double>(nullable: false),
                    EndKm = table.Column<double>(nullable: false),
                    TravelKm = table.Column<double>(nullable: false),
                    VehicleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleKms", x => x.VehicleKmID);
                    table.ForeignKey(
                        name: "FK_VehicleKms_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleKms_VehicleID",
                table: "VehicleKms",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelPrice");

            migrationBuilder.DropTable(
                name: "VehicleKms");
        }
    }
}
