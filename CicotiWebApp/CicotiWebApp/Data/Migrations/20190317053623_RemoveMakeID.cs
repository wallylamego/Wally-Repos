using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class RemoveMakeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Make_MakeID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_MakeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MakeID",
                table: "Vehicles",
                column: "MakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Make_MakeID",
                table: "Vehicles",
                column: "MakeID",
                principalTable: "Make",
                principalColumn: "MakeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
