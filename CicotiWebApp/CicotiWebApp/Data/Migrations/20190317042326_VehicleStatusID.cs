using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class VehicleStatusID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleStatusID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleStatusID",
                table: "Vehicles",
                column: "VehicleStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleStatus_VehicleStatusID",
                table: "Vehicles",
                column: "VehicleStatusID",
                principalTable: "VehicleStatus",
                principalColumn: "VehicleStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleStatus_VehicleStatusID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleStatusID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleStatusID",
                table: "Vehicles");
        }
    }
}
