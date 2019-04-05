using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class Investment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostInvestmentType",
                columns: table => new
                {
                    ActCostInvestmentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostInvestmentType", x => x.ActCostInvestmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostInvestment",
                columns: table => new
                {
                    ActCostInvestmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActCostInvestmentTypeID = table.Column<int>(nullable: false),
                    PrincipleID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostInvestment", x => x.ActCostInvestmentID);
                    table.ForeignKey(
                        name: "FK_ActCostInvestment_ActCostInvestmentType_ActCostInvestmentTypeID",
                        column: x => x.ActCostInvestmentTypeID,
                        principalTable: "ActCostInvestmentType",
                        principalColumn: "ActCostInvestmentTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostInvestment_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostInvestment_Principle_PrincipleID",
                        column: x => x.PrincipleID,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostInvestment_ActCostInvestmentTypeID",
                table: "ActCostInvestment",
                column: "ActCostInvestmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostInvestment_ActCostPeriodID",
                table: "ActCostInvestment",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostInvestment_PrincipleID",
                table: "ActCostInvestment",
                column: "PrincipleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostInvestment");

            migrationBuilder.DropTable(
                name: "ActCostInvestmentType");
        }
    }
}
