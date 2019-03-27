using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class VehicleKmsII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostPeriodID",
                table: "VehicleKms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleKms_ActCostPeriodID",
                table: "VehicleKms",
                column: "ActCostPeriodID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleKms_ActCostPeriods_ActCostPeriodID",
                table: "VehicleKms",
                column: "ActCostPeriodID",
                principalTable: "ActCostPeriods",
                principalColumn: "ActCostPeriodID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleKms_ActCostPeriods_ActCostPeriodID",
                table: "VehicleKms");

            migrationBuilder.DropIndex(
                name: "IX_VehicleKms_ActCostPeriodID",
                table: "VehicleKms");

            migrationBuilder.DropColumn(
                name: "ActCostPeriodID",
                table: "VehicleKms");
        }
    }
}
