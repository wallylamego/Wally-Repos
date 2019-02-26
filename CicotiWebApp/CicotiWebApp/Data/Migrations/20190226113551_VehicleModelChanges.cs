using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class VehicleModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubContractorID",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MakeID",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CostCentreID",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BranchID",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegNumberABB",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeID",
                table: "Vehicles",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employee_EmployeeID",
                table: "Vehicles",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employee_EmployeeID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EmployeeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RegNumberABB",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "SubContractorID",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MakeID",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostCentreID",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchID",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
