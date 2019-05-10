using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class AddSalesRepCodeII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReps_Employees_EmployeeID",
                table: "SalesReps");

            migrationBuilder.DropIndex(
                name: "IX_SalesReps_EmployeeID",
                table: "SalesReps");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "SalesReps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "SalesReps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReps_EmployeeID",
                table: "SalesReps",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReps_Employees_EmployeeID",
                table: "SalesReps",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
