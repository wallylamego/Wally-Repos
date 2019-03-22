using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostSiloAllocationSplit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiloID",
                table: "ActCostAllocationSplits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAllocationSplits_SiloID",
                table: "ActCostAllocationSplits",
                column: "SiloID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAllocationSplits_Silo_SiloID",
                table: "ActCostAllocationSplits",
                column: "SiloID",
                principalTable: "Silo",
                principalColumn: "SiloID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAllocationSplits_Silo_SiloID",
                table: "ActCostAllocationSplits");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAllocationSplits_SiloID",
                table: "ActCostAllocationSplits");

            migrationBuilder.DropColumn(
                name: "SiloID",
                table: "ActCostAllocationSplits");
        }
    }
}
