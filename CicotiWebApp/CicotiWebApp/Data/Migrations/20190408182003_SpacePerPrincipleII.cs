using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class SpacePerPrincipleII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostAlloctedSpacePerPrinciple",
                columns: table => new
                {
                    ActCostAlloctedSpacePerPrincipleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    PrincipleID = table.Column<int>(nullable: false),
                    PercentageAllocated = table.Column<double>(nullable: false),
                    AmtAllocated = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAlloctedSpacePerPrinciple", x => x.ActCostAlloctedSpacePerPrincipleID);
                    table.ForeignKey(
                        name: "FK_ActCostAlloctedSpacePerPrinciple_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAlloctedSpacePerPrinciple_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAlloctedSpacePerPrinciple_Principle_PrincipleID",
                        column: x => x.PrincipleID,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAlloctedSpacePerPrinciple_ActCostPeriodID",
                table: "ActCostAlloctedSpacePerPrinciple",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAlloctedSpacePerPrinciple_BranchID",
                table: "ActCostAlloctedSpacePerPrinciple",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAlloctedSpacePerPrinciple_PrincipleID",
                table: "ActCostAlloctedSpacePerPrinciple",
                column: "PrincipleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostAlloctedSpacePerPrinciple");
        }
    }
}
