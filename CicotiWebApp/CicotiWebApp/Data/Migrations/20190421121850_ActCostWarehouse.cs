using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostWarehouse",
                columns: table => new
                {
                    ActCostWarehouseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WarehouseName = table.Column<string>(nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    ActCostChannelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostWarehouse", x => x.ActCostWarehouseID);
                    table.ForeignKey(
                        name: "FK_ActCostWarehouse_ActCostChannel_ActCostChannelID",
                        column: x => x.ActCostChannelID,
                        principalTable: "ActCostChannel",
                        principalColumn: "ActCostChannelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostWarehouse_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostWarehouse_ActCostChannelID",
                table: "ActCostWarehouse",
                column: "ActCostChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostWarehouse_BranchID",
                table: "ActCostWarehouse",
                column: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostWarehouse");
        }
    }
}
