using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActivityCosting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostAllocatoionSplits",
                columns: table => new
                {
                    ActCostAllocatoionSplitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAllocatoionSplits", x => x.ActCostAllocatoionSplitID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostDrivers",
                columns: table => new
                {
                    ActCostDriverID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostDrivers", x => x.ActCostDriverID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostPeriods",
                columns: table => new
                {
                    ActCostPeriodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Period = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostPeriods", x => x.ActCostPeriodID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostTransactions",
                columns: table => new
                {
                    ActCostTransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeriodID = table.Column<int>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    ActCostDriverID = table.Column<int>(nullable: false),
                    ActCostAllocationSplitID = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    QtyPercAllocation = table.Column<double>(nullable: false),
                    AmtPercAllocation = table.Column<double>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: true),
                    ActCostAllocatoionSplitID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostTransactions", x => x.ActCostTransactionID);
                    table.ForeignKey(
                        name: "FK_ActCostTransactions_ActCostAllocatoionSplits_ActCostAllocatoionSplitID",
                        column: x => x.ActCostAllocatoionSplitID,
                        principalTable: "ActCostAllocatoionSplits",
                        principalColumn: "ActCostAllocatoionSplitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostTransactions_ActCostDrivers_ActCostDriverID",
                        column: x => x.ActCostDriverID,
                        principalTable: "ActCostDrivers",
                        principalColumn: "ActCostDriverID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostTransactions_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostTransactions_ActCostAllocatoionSplitID",
                table: "ActCostTransactions",
                column: "ActCostAllocatoionSplitID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostTransactions_ActCostDriverID",
                table: "ActCostTransactions",
                column: "ActCostDriverID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostTransactions_ActCostPeriodID",
                table: "ActCostTransactions",
                column: "ActCostPeriodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostTransactions");

            migrationBuilder.DropTable(
                name: "ActCostAllocatoionSplits");

            migrationBuilder.DropTable(
                name: "ActCostDrivers");

            migrationBuilder.DropTable(
                name: "ActCostPeriods");
        }
    }
}
