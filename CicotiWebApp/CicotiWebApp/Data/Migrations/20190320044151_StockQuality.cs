using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class StockQuality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockQualityID",
                table: "StockCountItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StockQuality",
                columns: table => new
                {
                    StockQualityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockQuality", x => x.StockQualityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockCountItems_StockQualityID",
                table: "StockCountItems",
                column: "StockQualityID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockCountItems_StockQuality_StockQualityID",
                table: "StockCountItems",
                column: "StockQualityID",
                principalTable: "StockQuality",
                principalColumn: "StockQualityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockCountItems_StockQuality_StockQualityID",
                table: "StockCountItems");

            migrationBuilder.DropTable(
                name: "StockQuality");

            migrationBuilder.DropIndex(
                name: "IX_StockCountItems_StockQualityID",
                table: "StockCountItems");

            migrationBuilder.DropColumn(
                name: "StockQualityID",
                table: "StockCountItems");
        }
    }
}
