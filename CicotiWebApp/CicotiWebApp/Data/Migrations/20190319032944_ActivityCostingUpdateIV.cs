using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActivityCostingUpdateIV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocationSplitID",
                table: "ActCostTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActCostAllocatoionSplits",
                table: "ActCostAllocatoionSplits");

            migrationBuilder.RenameTable(
                name: "ActCostAllocatoionSplits",
                newName: "ActCostAllocationSplits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActCostAllocationSplits",
                table: "ActCostAllocationSplits",
                column: "ActCostAllocationSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocationSplitID",
                principalTable: "ActCostAllocationSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "ActCostTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActCostAllocationSplits",
                table: "ActCostAllocationSplits");

            migrationBuilder.RenameTable(
                name: "ActCostAllocationSplits",
                newName: "ActCostAllocatoionSplits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActCostAllocatoionSplits",
                table: "ActCostAllocatoionSplits",
                column: "ActCostAllocationSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocationSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocationSplitID",
                principalTable: "ActCostAllocatoionSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
