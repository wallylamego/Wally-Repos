using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostPerPrincipleII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostAccountPerPrinciple",
                columns: table => new
                {
                    ActCostAccountPerPrincipleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    PrincipalID = table.Column<int>(nullable: false),
                    ActCostAccountID = table.Column<int>(nullable: false),
                    AllocAccountPerc = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    PrincipleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAccountPerPrinciple", x => x.ActCostAccountPerPrincipleID);
                    table.ForeignKey(
                        name: "FK_ActCostAccountPerPrinciple_ActCostAccount_ActCostAccountID",
                        column: x => x.ActCostAccountID,
                        principalTable: "ActCostAccount",
                        principalColumn: "ActCostAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAccountPerPrinciple_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAccountPerPrinciple_Principle_PrincipleID",
                        column: x => x.PrincipleID,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountPerPrinciple_ActCostAccountID",
                table: "ActCostAccountPerPrinciple",
                column: "ActCostAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountPerPrinciple_ActCostPeriodID",
                table: "ActCostAccountPerPrinciple",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccountPerPrinciple_PrincipleID",
                table: "ActCostAccountPerPrinciple",
                column: "PrincipleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostAccountPerPrinciple");
        }
    }
}
