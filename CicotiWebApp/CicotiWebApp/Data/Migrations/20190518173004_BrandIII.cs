using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class BrandIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SKUID",
                table: "SkuUomLinks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkuUomLinks_SKUID",
                table: "SkuUomLinks",
                column: "SKUID");

            migrationBuilder.AddForeignKey(
                name: "FK_SkuUomLinks_SKUs_SKUID",
                table: "SkuUomLinks",
                column: "SKUID",
                principalTable: "SKUs",
                principalColumn: "SKUID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkuUomLinks_SKUs_SKUID",
                table: "SkuUomLinks");

            migrationBuilder.DropIndex(
                name: "IX_SkuUomLinks_SKUID",
                table: "SkuUomLinks");

            migrationBuilder.DropColumn(
                name: "SKUID",
                table: "SkuUomLinks");
        }
    }
}
