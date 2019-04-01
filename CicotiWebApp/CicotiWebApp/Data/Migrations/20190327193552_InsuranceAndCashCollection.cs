using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class InsuranceAndCashCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "ActCostInsuranceType",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ActCostCashCollectionCost",
                columns: table => new
                {
                    ActCostCashCollectionCostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostCashCollectionCost", x => x.ActCostCashCollectionCostID);
                    table.ForeignKey(
                        name: "FK_ActCostCashCollectionCost_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostCashCollectionCost_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostCashCollectionCost_ActCostPeriodID",
                table: "ActCostCashCollectionCost",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostCashCollectionCost_BranchID",
                table: "ActCostCashCollectionCost",
                column: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostCashCollectionCost");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ActCostInsuranceType");
        }
    }
}
