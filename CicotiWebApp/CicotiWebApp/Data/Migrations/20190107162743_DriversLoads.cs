using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class DriversLoads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoadID",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    Surname = table.Column<string>(maxLength: 30, nullable: false),
                    CellNumber = table.Column<string>(maxLength: 15, nullable: false),
                    PDPExpiryDate = table.Column<DateTime>(nullable: false),
                    IDNumber = table.Column<string>(maxLength: 20, nullable: true),
                    SubContractorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                    table.ForeignKey(
                        name: "FK_Drivers_SubContractor_SubContractorID",
                        column: x => x.SubContractorID,
                        principalTable: "SubContractor",
                        principalColumn: "SubContractorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loads",
                columns: table => new
                {
                    LoadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoadName = table.Column<string>(nullable: true),
                    LoadDate = table.Column<string>(nullable: true),
                    VehicleID = table.Column<int>(nullable: true),
                    DriverID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.LoadID);
                    table.ForeignKey(
                        name: "FK_Loads_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loads_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LoadID",
                table: "Invoices",
                column: "LoadID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_SubContractorID",
                table: "Drivers",
                column: "SubContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_DriverID",
                table: "Loads",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_VehicleID",
                table: "Loads",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Loads_LoadID",
                table: "Invoices",
                column: "LoadID",
                principalTable: "Loads",
                principalColumn: "LoadID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Loads_LoadID",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Loads");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_LoadID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LoadID",
                table: "Invoices");
        }
    }
}
