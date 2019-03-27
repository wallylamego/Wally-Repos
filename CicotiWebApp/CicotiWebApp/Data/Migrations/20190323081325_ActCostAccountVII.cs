using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountVII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AccountCost",
                table: "ActCostBalanceAllocation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ActCostAccountBalanceID",
                table: "ActCostBalanceAllocation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AllocAccountCost",
                table: "ActCostBalanceAllocation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ActCostAccountID",
                table: "ActCostAccountBalance",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostBalanceAllocation_ActCostAccountBalanceID",
                table: "ActCostBalanceAllocation",
                column: "ActCostAccountBalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountBalance_ActCostAccountID",
                table: "ActCostAccountBalance",
                column: "ActCostAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccountBalance_ActCostAccount_ActCostAccountID",
                table: "ActCostAccountBalance",
                column: "ActCostAccountID",
                principalTable: "ActCostAccount",
                principalColumn: "ActCostAccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostBalanceAllocation_ActCostAccountBalance_ActCostAccountBalanceID",
                table: "ActCostBalanceAllocation",
                column: "ActCostAccountBalanceID",
                principalTable: "ActCostAccountBalance",
                principalColumn: "ActCostAccountBalanceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccountBalance_ActCostAccount_ActCostAccountID",
                table: "ActCostAccountBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_ActCostBalanceAllocation_ActCostAccountBalance_ActCostAccountBalanceID",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_ActCostBalanceAllocation_ActCostAccountBalanceID",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccountBalance_ActCostAccountID",
                table: "ActCostAccountBalance");

            migrationBuilder.DropColumn(
                name: "AccountCost",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropColumn(
                name: "ActCostAccountBalanceID",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropColumn(
                name: "AllocAccountCost",
                table: "ActCostBalanceAllocation");

            migrationBuilder.DropColumn(
                name: "ActCostAccountID",
                table: "ActCostAccountBalance");
        }
    }
}
