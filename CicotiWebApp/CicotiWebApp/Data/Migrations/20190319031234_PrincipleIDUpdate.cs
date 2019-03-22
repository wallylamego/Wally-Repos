using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class PrincipleIDUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrincipalID",
                table: "ActCostTransactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrincipleID",
                table: "ActCostTransactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActCostTransactions_PrincipleID",
                table: "ActCostTransactions",
                column: "PrincipleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostTransactions_Principle_PrincipleID",
                table: "ActCostTransactions",
                column: "PrincipleID",
                principalTable: "Principle",
                principalColumn: "PrincipleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostTransactions_Principle_PrincipleID",
                table: "ActCostTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ActCostTransactions_PrincipleID",
                table: "ActCostTransactions");

            migrationBuilder.DropColumn(
                name: "PrincipalID",
                table: "ActCostTransactions");

            migrationBuilder.DropColumn(
                name: "PrincipleID",
                table: "ActCostTransactions");
        }
    }
}
