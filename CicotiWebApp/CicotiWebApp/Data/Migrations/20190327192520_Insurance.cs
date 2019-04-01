using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class Insurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostInsuranceType",
                columns: table => new
                {
                    ActCostInsuranceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ActCostDriverID = table.Column<int>(nullable: false),
                    ActCostPeriodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostInsuranceType", x => x.ActCostInsuranceTypeID);
                    table.ForeignKey(
                        name: "FK_ActCostInsuranceType_ActCostDrivers_ActCostDriverID",
                        column: x => x.ActCostDriverID,
                        principalTable: "ActCostDrivers",
                        principalColumn: "ActCostDriverID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostInsuranceType_ActCostPeriods_ActCostPeriodID",
                        column: x => x.ActCostPeriodID,
                        principalTable: "ActCostPeriods",
                        principalColumn: "ActCostPeriodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostInsuranceType_ActCostDriverID",
                table: "ActCostInsuranceType",
                column: "ActCostDriverID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostInsuranceType_ActCostPeriodID",
                table: "ActCostInsuranceType",
                column: "ActCostPeriodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostInsuranceType");
        }
    }
}
