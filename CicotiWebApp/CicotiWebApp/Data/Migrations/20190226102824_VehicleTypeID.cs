using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class VehicleTypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeID",
                table: "Models",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_VehicleTypeID",
                table: "Models",
                column: "VehicleTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_VehicleTypes_VehicleTypeID",
                table: "Models",
                column: "VehicleTypeID",
                principalTable: "VehicleTypes",
                principalColumn: "VehicleTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_VehicleTypes_VehicleTypeID",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_VehicleTypeID",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "VehicleTypeID",
                table: "Models");
        }
    }
}
