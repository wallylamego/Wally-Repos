using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostSiloAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostSiloAllocationID",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Silo",
                columns: table => new
                {
                    SiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiloName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silo", x => x.SiloID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostSiloAllocations",
                columns: table => new
                {
                    ActCostSiloAllocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActCostAllocationSplitID = table.Column<int>(nullable: false),
                    SiloID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    AllocPercentage = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostSiloAllocations", x => x.ActCostSiloAllocationID);
                    table.ForeignKey(
                        name: "FK_ActCostSiloAllocations_ActCostAllocationSplits_ActCostAllocationSplitID",
                        column: x => x.ActCostAllocationSplitID,
                        principalTable: "ActCostAllocationSplits",
                        principalColumn: "ActCostAllocationSplitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostSiloAllocations_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostSiloAllocations_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostSiloAllocations_Silo_SiloID",
                        column: x => x.SiloID,
                        principalTable: "Silo",
                        principalColumn: "SiloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ActCostSiloAllocationID",
                table: "Employees",
                column: "ActCostSiloAllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostSiloAllocations_ActCostAllocationSplitID",
                table: "ActCostSiloAllocations",
                column: "ActCostAllocationSplitID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostSiloAllocations_ActCostPeriodID",
                table: "ActCostSiloAllocations",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostSiloAllocations_EmployeeID",
                table: "ActCostSiloAllocations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostSiloAllocations_SiloID",
                table: "ActCostSiloAllocations",
                column: "SiloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ActCostSiloAllocations_ActCostSiloAllocationID",
                table: "Employees",
                column: "ActCostSiloAllocationID",
                principalTable: "ActCostSiloAllocations",
                principalColumn: "ActCostSiloAllocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ActCostSiloAllocations_ActCostSiloAllocationID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ActCostSiloAllocations");

            migrationBuilder.DropTable(
                name: "Silo");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ActCostSiloAllocationID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ActCostSiloAllocationID",
                table: "Employees");
        }
    }
}
