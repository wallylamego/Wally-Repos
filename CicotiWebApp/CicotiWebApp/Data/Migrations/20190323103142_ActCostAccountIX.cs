using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountIX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostAllocationSplitID",
                table: "ActCostAccount",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActCostSubCategoryID",
                table: "ActCostAccount",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_ActCostAllocationSplitID",
                table: "ActCostAccount",
                column: "ActCostAllocationSplitID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_ActCostSubCategoryID",
                table: "ActCostAccount",
                column: "ActCostSubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccount_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "ActCostAccount",
                column: "ActCostAllocationSplitID",
                principalTable: "ActCostAllocationSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccount_ActSubCostCategory_ActCostSubCategoryID",
                table: "ActCostAccount",
                column: "ActCostSubCategoryID",
                principalTable: "ActSubCostCategory",
                principalColumn: "ActCostSubCategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccount_ActCostAllocationSplits_ActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccount_ActSubCostCategory_ActCostSubCategoryID",
                table: "ActCostAccount");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccount_ActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccount_ActCostSubCategoryID",
                table: "ActCostAccount");

            migrationBuilder.DropColumn(
                name: "ActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropColumn(
                name: "ActCostSubCategoryID",
                table: "ActCostAccount");
        }
    }
}
