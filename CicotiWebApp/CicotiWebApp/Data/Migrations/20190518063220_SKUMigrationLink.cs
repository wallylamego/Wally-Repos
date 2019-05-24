using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class SKUMigrationLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkuUomLinks",
                columns: table => new
                {
                    SkuUomLinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    FromUOMID = table.Column<int>(nullable: false),
                    ToUOMID = table.Column<int>(nullable: false),
                    ConversionFactor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuUomLinks", x => x.SkuUomLinkID);
                    table.ForeignKey(
                        name: "FK_SkuUomLinks_UOM_FromUOMID",
                        column: x => x.FromUOMID,
                        principalTable: "UOM",
                        principalColumn: "UOMID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkuUomLinks_UOM_ToUOMID",
                        column: x => x.ToUOMID,
                        principalTable: "UOM",
                        principalColumn: "UOMID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkuUomLinks_FromUOMID",
                table: "SkuUomLinks",
                column: "FromUOMID");

            migrationBuilder.CreateIndex(
                name: "IX_SkuUomLinks_ToUOMID",
                table: "SkuUomLinks",
                column: "ToUOMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkuUomLinks");
        }
    }
}
