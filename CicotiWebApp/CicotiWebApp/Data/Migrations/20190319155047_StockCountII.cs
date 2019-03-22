using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class StockCountII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrincipleID",
                table: "SKUs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SKUs_PrincipleID",
                table: "SKUs",
                column: "PrincipleID");

            migrationBuilder.AddForeignKey(
                name: "FK_SKUs_Principle_PrincipleID",
                table: "SKUs",
                column: "PrincipleID",
                principalTable: "Principle",
                principalColumn: "PrincipleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SKUs_Principle_PrincipleID",
                table: "SKUs");

            migrationBuilder.DropIndex(
                name: "IX_SKUs_PrincipleID",
                table: "SKUs");

            migrationBuilder.DropColumn(
                name: "PrincipleID",
                table: "SKUs");
        }
    }
}
