using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountXI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostAccountID",
                table: "ActCostBalanceAllocation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostBalanceAllocation_ActCostAccountID",
                table: "ActCostBalanceAllocation",
                column: "ActCostAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostBalanceAllocation_ActCostAccount_ActCostAccountID",
                table: "ActCostBalanceAllocation",
                column: "ActCostAccountID",
                principalTable: "ActCostAccount",
                principalColumn: "ActCostAccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostBalanceAllocation_ActCostAccount_ActCostAccountID",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_ActCostBalanceAllocation_ActCostAccountID",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropColumn(
                name: "ActCostAccountID",
                table: "ActCostBalanceAllocation");
        }
    }
}
