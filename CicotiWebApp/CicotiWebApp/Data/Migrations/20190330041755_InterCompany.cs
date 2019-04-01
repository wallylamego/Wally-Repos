using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class InterCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterCompany",
                columns: table => new
                {
                    InterCompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    ExchangeRateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterCompany", x => x.InterCompanyID);
                    table.ForeignKey(
                        name: "FK_InterCompany_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterCompany_ExchangeRates_ExchangeRateID",
                        column: x => x.ExchangeRateID,
                        principalTable: "ExchangeRates",
                        principalColumn: "ExchangeRateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterCompany_ActCostPeriodID",
                table: "InterCompany",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_InterCompany_ExchangeRateID",
                table: "InterCompany",
                column: "ExchangeRateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterCompany");
        }
    }
}
