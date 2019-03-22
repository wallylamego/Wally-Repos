using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActivityCostingUpdateIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocatoionSplitID",
                table: "ActCostTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ActCostTransactions_ActCostAllocatoionSplitID",
                table: "ActCostTransactions");

            migrationBuilder.DropColumn(
                name: "ActCostAllocatoionSplitID",
                table: "ActCostTransactions");

            migrationBuilder.RenameColumn(
                name: "ActCostAllocatoionSplitID",
                table: "ActCostAllocatoionSplits",
                newName: "ActCostAllocationSplitID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostTransactions_ActCostAllocationSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocationSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocationSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocationSplitID",
                principalTable: "ActCostAllocatoionSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocationSplitID",
                table: "ActCostTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ActCostTransactions_ActCostAllocationSplitID",
                table: "ActCostTransactions");

            migrationBuilder.RenameColumn(
                name: "ActCostAllocationSplitID",
                table: "ActCostAllocatoionSplits",
                newName: "ActCostAllocatoionSplitID");

            migrationBuilder.AddColumn<int>(
                name: "ActCostAllocatoionSplitID",
                table: "ActCostTransactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostTransactions_ActCostAllocatoionSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocatoionSplitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocatoionSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocatoionSplitID",
                principalTable: "ActCostAllocatoionSplits",
                principalColumn: "ActCostAllocatoionSplitID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
