using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class PrincipleSiloLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiloID",
                table: "Principle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Principle_SiloID",
                table: "Principle",
                column: "SiloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Principle_Silo_SiloID",
                table: "Principle",
                column: "SiloID",
                principalTable: "Silo",
                principalColumn: "SiloID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principle_Silo_SiloID",
                table: "Principle");

            migrationBuilder.DropIndex(
                name: "IX_Principle_SiloID",
                table: "Principle");

            migrationBuilder.DropColumn(
                name: "SiloID",
                table: "Principle");
        }
    }
}
