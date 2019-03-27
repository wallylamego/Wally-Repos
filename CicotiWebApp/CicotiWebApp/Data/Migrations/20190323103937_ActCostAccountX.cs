using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccount_ActCostAllocationSplits_GetActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccount_GetActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropColumn(
                name: "GetActCostAllocationSplitID",
                table: "ActCostAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetActCostAllocationSplitID",
                table: "ActCostAccount",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_GetActCostAllocationSplitID",
                table: "ActCostAccount",
                column: "GetActCostAllocationSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccount_ActCostAllocationSplits_GetActCostAllocationSplitID",
                table: "ActCostAccount",
                column: "GetActCostAllocationSplitID",
                principalTable: "ActCostAllocationSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
