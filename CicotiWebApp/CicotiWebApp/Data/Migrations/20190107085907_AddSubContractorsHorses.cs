using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class AddSubContractorsHorses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InvoiceStatus");

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(maxLength: 10, nullable: false),
                    VinNo = table.Column<string>(maxLength: 20, nullable: false),
                    LicenseExpiry = table.Column<DateTime>(nullable: false),
                    InsuranceExpiry = table.Column<DateTime>(nullable: false),
                    FleetNo = table.Column<string>(maxLength: 6, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 10, nullable: true),
                    GPSUnitNo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.VehicleID);
                });

            migrationBuilder.CreateTable(
                name: "SubContractor",
                columns: table => new
                {
                    SubContractorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AccountNo = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContractor", x => x.SubContractorID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "SubContractor");

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "InvoiceStatus",
                nullable: false,
                defaultValue: 0);
        }
    }
}
