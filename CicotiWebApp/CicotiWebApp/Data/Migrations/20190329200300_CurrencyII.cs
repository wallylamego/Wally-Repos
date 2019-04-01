using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class CurrencyII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    ExchangeRateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstCurrencyID = table.Column<int>(nullable: false),
                    SecondCurrencyID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AverageRate = table.Column<double>(nullable: false),
                    ClosingRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.ExchangeRateID);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currency_FirstCurrencyID",
                        column: x => x.FirstCurrencyID,
                        principalTable: "Currency",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currency_SecondCurrencyID",
                        column: x => x.SecondCurrencyID,
                        principalTable: "Currency",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_ActCostPeriodID",
                table: "ExchangeRates",
                column: "ActCostPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_FirstCurrencyID",
                table: "ExchangeRates",
                column: "FirstCurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_SecondCurrencyID",
                table: "ExchangeRates",
                column: "SecondCurrencyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
