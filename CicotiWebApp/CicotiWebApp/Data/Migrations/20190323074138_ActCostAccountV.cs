using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostDriverID",
                table: "ActCostAccount",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GetActCostAllocationSplitID",
                table: "ActCostAccount",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActCostBalanceAllocation",
                columns: table => new
                {
                    ActCostBalanceAllocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActCostDriverID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    PrincipleID = table.Column<int>(nullable: false),
                    ActCostAllocationSplitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostBalanceAllocation", x => x.ActCostBalanceAllocationID);
                    table.ForeignKey(
                        name: "FK_ActCostBalanceAllocation_ActCostAllocationSplits_ActCostAllocationSplitID",
                        column: x => x.ActCostAllocationSplitID,
                        principalTable: "ActCostAllocationSplits",
                        principalColumn: "ActCostAllocationSplitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostBalanceAllocation_ActCostDrivers_ActCostDriverID",
                        column: x => x.ActCostDriverID,
                        principalTable: "ActCostDrivers",
                        principalColumn: "ActCostDriverID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostBalanceAllocation_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostBalanceAllocation_Principle_PrincipleID",
                        column: x => x.PrincipleID,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_ActCostDriverID",
                table: "ActCostAccount",
                column: "ActCostDriverID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_GetActCostAllocationSplitID",
                table: "ActCostAccount",
                column: "GetActCostAllocationSplitID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostBalanceAllocation_ActCostAllocationSplitID",
                table: "ActCostBalanceAllocation",
                column: "ActCostAllocationSplitID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostBalanceAllocation_ActCostDriverID",
                table: "ActCostBalanceAllocation",
                column: "ActCostDriverID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostBalanceAllocation_ActCostPeriodID",
                table: "ActCostBalanceAllocation",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostBalanceAllocation_PrincipleID",
                table: "ActCostBalanceAllocation",
                column: "PrincipleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccount_ActCostDrivers_ActCostDriverID",
                table: "ActCostAccount",
                column: "ActCostDriverID",
                principalTable: "ActCostDrivers",
                principalColumn: "ActCostDriverID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccount_ActCostAllocationSplits_GetActCostAllocationSplitID",
                table: "ActCostAccount",
                column: "GetActCostAllocationSplitID",
                principalTable: "ActCostAllocationSplits",
                principalColumn: "ActCostAllocationSplitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccount_ActCostDrivers_ActCostDriverID",
                table: "ActCostAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccount_ActCostAllocationSplits_GetActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropTable(
                name: "ActCostBalanceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccount_ActCostDriverID",
                table: "ActCostAccount");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccount_GetActCostAllocationSplitID",
                table: "ActCostAccount");

            migrationBuilder.DropColumn(
                name: "ActCostDriverID",
                table: "ActCostAccount");

            migrationBuilder.DropColumn(
                name: "GetActCostAllocationSplitID",
                table: "ActCostAccount");
        }
    }
}
