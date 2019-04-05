using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class PrincipleBalances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostPrincipleBalance",
                columns: table => new
                {
                    ActCostPrincipleBalanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrincipleID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostPrincipleBalance", x => x.ActCostPrincipleBalanceID);
                    table.ForeignKey(
                        name: "FK_ActCostPrincipleBalance_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostPrincipleBalance_Principle_PrincipleID",
                        column: x => x.PrincipleID,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostPrincipleBalance_ActCostPeriodID",
                table: "ActCostPrincipleBalance",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostPrincipleBalance_PrincipleID",
                table: "ActCostPrincipleBalance",
                column: "PrincipleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostPrincipleBalance");
        }
    }
}
