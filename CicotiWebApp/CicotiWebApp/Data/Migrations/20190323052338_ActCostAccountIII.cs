using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodID",
                table: "ActCostAccountBalance",
                newName: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountBalance_ActCostPeriodID",
                table: "ActCostAccountBalance",
                column: "ActCostPeriodID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccountBalance_ActCostPeriods_ActCostPeriodID",
                table: "ActCostAccountBalance",
                column: "ActCostPeriodID",
                principalTable: "ActCostPeriods",
                principalColumn: "ActCostPeriodID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccountBalance_ActCostPeriods_ActCostPeriodID",
                table: "ActCostAccountBalance");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccountBalance_ActCostPeriodID",
                table: "ActCostAccountBalance");

            migrationBuilder.RenameColumn(
                name: "ActCostPeriodID",
                table: "ActCostAccountBalance",
                newName: "PeriodID");
        }
    }
}
