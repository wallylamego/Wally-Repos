using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class VehiclePurposeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiclePurposeID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehiclePurpose",
                columns: table => new
                {
                    VehiclePurposeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePurpose", x => x.VehiclePurposeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehiclePurposeID",
                table: "Vehicles",
                column: "VehiclePurposeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehiclePurpose_VehiclePurposeID",
                table: "Vehicles",
                column: "VehiclePurposeID",
                principalTable: "VehiclePurpose",
                principalColumn: "VehiclePurposeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehiclePurpose_VehiclePurposeID",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehiclePurpose");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehiclePurposeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehiclePurposeID",
                table: "Vehicles");
        }
    }
}
