using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class FixedAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostFixedAssetAccount",
                columns: table => new
                {
                    ActCostFixedAssetAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActCostFixedAssetCostAccountID = table.Column<int>(nullable: false),
                    ActCostFixedAssetAccDepAccountID = table.Column<int>(nullable: false),
                    ActCostFixedAssetDepAccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostFixedAssetAccount", x => x.ActCostFixedAssetAccountID);
                    table.ForeignKey(
                        name: "FK_ActCostFixedAssetAccount_ActCostAccount_ActCostFixedAssetAccDepAccountID",
                        column: x => x.ActCostFixedAssetAccDepAccountID,
                        principalTable: "ActCostAccount",
                        principalColumn: "ActCostAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostFixedAssetAccount_ActCostAccount_ActCostFixedAssetCostAccountID",
                        column: x => x.ActCostFixedAssetCostAccountID,
                        principalTable: "ActCostAccount",
                        principalColumn: "ActCostAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostFixedAssetAccount_ActCostAccount_ActCostFixedAssetDepAccountID",
                        column: x => x.ActCostFixedAssetDepAccountID,
                        principalTable: "ActCostAccount",
                        principalColumn: "ActCostAccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostFixedAssetAccount_ActCostFixedAssetAccDepAccountID",
                table: "ActCostFixedAssetAccount",
                column: "ActCostFixedAssetAccDepAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostFixedAssetAccount_ActCostFixedAssetCostAccountID",
                table: "ActCostFixedAssetAccount",
                column: "ActCostFixedAssetCostAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostFixedAssetAccount_ActCostFixedAssetDepAccountID",
                table: "ActCostFixedAssetAccount",
                column: "ActCostFixedAssetDepAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostFixedAssetAccount");
        }
    }
}
