using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class EmployeeIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeID",
                table: "Vehicles",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employees_EmployeeID",
                table: "Vehicles",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employees_EmployeeID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EmployeeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Vehicles");
        }
    }
}
