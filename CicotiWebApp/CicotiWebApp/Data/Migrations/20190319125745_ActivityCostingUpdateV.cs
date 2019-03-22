using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActivityCostingUpdateV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostAllocationSplitID",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ActCostAllocationSplitID",
                table: "Employees",
                column: "ActCostAllocationSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "Employees",
                column: "ActCostAllocationSplitID",
                principalTable: "ActCostAllocationSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ActCostAllocationSplitID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ActCostAllocationSplitID",
                table: "Employees");
        }
    }
}
