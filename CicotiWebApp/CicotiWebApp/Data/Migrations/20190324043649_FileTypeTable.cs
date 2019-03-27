using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class FileTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostAllocationSplitID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ActCostAllocationSplitID",
                table: "Vehicles",
                column: "ActCostAllocationSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "Vehicles",
                column: "ActCostAllocationSplitID",
                principalTable: "ActCostAllocationSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ActCostAllocationSplitID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ActCostAllocationSplitID",
                table: "Vehicles");
        }
    }
}
