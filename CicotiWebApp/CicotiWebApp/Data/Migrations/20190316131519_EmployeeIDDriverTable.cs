using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class EmployeeIDDriverTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_EmployeeID",
                table: "Drivers",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Employees_EmployeeID",
                table: "Drivers",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Employees_EmployeeID",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_EmployeeID",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Drivers");
        }
    }
}
