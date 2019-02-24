using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class MakeModelEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AcquisitionDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "AcquistionCost",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Vehicles",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostCentreID",
                table: "Vehicles",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DepreciationMonths",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FixedAssetsNumber",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeID",
                table: "Vehicles",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Vehicles",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostCentreID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobDescriptionID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportsToID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleRepID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ERPBranchID = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "CostCentre",
                columns: table => new
                {
                    CostCentreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostCentreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCentre", x => x.CostCentreID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "JobDescription",
                columns: table => new
                {
                    JobDescriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescription", x => x.JobDescriptionID);
                });

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    MakeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MakeName = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.MakeID);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BranchID",
                table: "Vehicles",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CostCentreID",
                table: "Vehicles",
                column: "CostCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MakeID",
                table: "Vehicles",
                column: "MakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelID",
                table: "Vehicles",
                column: "ModelID");

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
                name: "FK_Employee_Branch_BranchID",
                table: "Employee",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CostCentre_CostCentreID",
                table: "Employee",
                column: "CostCentreID",
                principalTable: "CostCentre",
                principalColumn: "CostCentreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobDescription_JobDescriptionID",
                table: "Employee",
                column: "JobDescriptionID",
                principalTable: "JobDescription",
                principalColumn: "JobDescriptionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Branch_BranchID",
                table: "Vehicles",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_CostCentre_CostCentreID",
                table: "Vehicles",
                column: "CostCentreID",
                principalTable: "CostCentre",
                principalColumn: "CostCentreID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Make_MakeID",
                table: "Vehicles",
                column: "MakeID",
                principalTable: "Make",
                principalColumn: "MakeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Model_ModelID",
                table: "Vehicles",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Branch_BranchID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CostCentre_CostCentreID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobDescription_JobDescriptionID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Branch_BranchID",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_CostCentre_CostCentreID",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Make_MakeID",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Model_ModelID",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "CostCentre");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "JobDescription");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_BranchID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CostCentreID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_MakeID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ModelID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BranchID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CostCentreID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobDescriptionID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AcquisitionDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AcquistionCost",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CostCentreID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DepreciationMonths",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FixedAssetsNumber",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CostCentreID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobDescriptionID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ReportsToID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SaleRepID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Employee");
        }
    }
}
