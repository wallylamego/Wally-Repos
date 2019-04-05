using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class MainPrincipleID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainPrincipleID",
                table: "Principle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Principle_MainPrincipleID",
                table: "Principle",
                column: "MainPrincipleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Principle_Principle_MainPrincipleID",
                table: "Principle",
                column: "MainPrincipleID",
                principalTable: "Principle",
                principalColumn: "PrincipleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principle_Principle_MainPrincipleID",
                table: "Principle");

            migrationBuilder.DropIndex(
                name: "IX_Principle_MainPrincipleID",
                table: "Principle");

            migrationBuilder.DropColumn(
                name: "MainPrincipleID",
                table: "Principle");
        }
    }
}
