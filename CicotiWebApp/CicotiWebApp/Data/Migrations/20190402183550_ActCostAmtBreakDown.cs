using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAmtBreakDown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostAccountAmtPrinciple",
                columns: table => new
                {
                    ActCostAccountAmtPrincipleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrincipleID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    ActCostAccountID = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAccountAmtPrinciple", x => x.ActCostAccountAmtPrincipleID);
                    table.ForeignKey(
                        name: "FK_ActCostAccountAmtPrinciple_ActCostAccount_ActCostAccountID",
                        column: x => x.ActCostAccountID,
                        principalTable: "ActCostAccount",
                        principalColumn: "ActCostAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAccountAmtPrinciple_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAccountAmtPrinciple_Principle_PrincipleID",
                        column: x => x.PrincipleID,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountAmtPrinciple_ActCostAccountID",
                table: "ActCostAccountAmtPrinciple",
                column: "ActCostAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountAmtPrinciple_ActCostPeriodID",
                table: "ActCostAccountAmtPrinciple",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountAmtPrinciple_PrincipleID",
                table: "ActCostAccountAmtPrinciple",
                column: "PrincipleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostAccountAmtPrinciple");
        }
    }
}
