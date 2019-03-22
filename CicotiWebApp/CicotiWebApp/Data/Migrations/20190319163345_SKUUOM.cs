using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class SKUUOM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOM",
                table: "SKUs");

            migrationBuilder.AddColumn<int>(
                name: "UOMID",
                table: "SKUs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SKUs_UOMID",
                table: "SKUs",
                column: "UOMID");

            migrationBuilder.AddForeignKey(
                name: "FK_SKUs_UOM_UOMID",
                table: "SKUs",
                column: "UOMID",
                principalTable: "UOM",
                principalColumn: "UOMID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SKUs_UOM_UOMID",
                table: "SKUs");

            migrationBuilder.DropIndex(
                name: "IX_SKUs_UOMID",
                table: "SKUs");

            migrationBuilder.DropColumn(
                name: "UOMID",
                table: "SKUs");

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "SKUs",
                nullable: true);
        }
    }
}
