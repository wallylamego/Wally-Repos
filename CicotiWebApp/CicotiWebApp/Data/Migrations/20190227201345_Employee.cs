using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employee_EmployeeID",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EmployeeID",
                table: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankAccount = table.Column<string>(nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    CostCentreID = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EmployeeNo = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    JobDescriptionID = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PastelRepCode = table.Column<string>(nullable: true),
                    PastelRepName = table.Column<string>(nullable: true),
                    ReportsToID = table.Column<int>(nullable: false),
                    SaleRepID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    SalesRepID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_CostCentre_CostCentreID",
                        column: x => x.CostCentreID,
                        principalTable: "CostCentre",
                        principalColumn: "CostCentreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_JobDescription_JobDescriptionID",
                        column: x => x.JobDescriptionID,
                        principalTable: "JobDescription",
                        principalColumn: "JobDescriptionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeID",
                table: "Vehicles",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BranchID",
                table: "Employee",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CostCentreID",
                table: "Employee",
                column: "CostCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobDescriptionID",
                table: "Employee",
                column: "JobDescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employee_EmployeeID",
                table: "Vehicles",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
