using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class StockCountItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockCountItems",
                columns: table => new
                {
                    StockCountItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKUID = table.Column<int>(nullable: false),
                    UOMID = table.Column<int>(nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCountItems", x => x.StockCountItemID);
                    table.ForeignKey(
                        name: "FK_StockCountItems_SKUs_SKUID",
                        column: x => x.SKUID,
                        principalTable: "SKUs",
                        principalColumn: "SKUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCountItems_UOM_UOMID",
                        column: x => x.UOMID,
                        principalTable: "UOM",
                        principalColumn: "UOMID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockCountItems_SKUID",
                table: "StockCountItems",
                column: "SKUID");

            migrationBuilder.CreateIndex(
                name: "IX_StockCountItems_UOMID",
                table: "StockCountItems",
                column: "UOMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockCountItems");
        }
    }
}
