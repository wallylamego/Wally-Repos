using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ReportsToID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReportsToID",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsToID",
                table: "Employees",
                column: "ReportsToID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportsToID",
                table: "Employees",
                column: "ReportsToID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportsToID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportsToID",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ReportsToID",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
