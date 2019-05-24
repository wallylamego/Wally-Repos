using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class Region : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionID",
                table: "Branch",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_RegionID",
                table: "Branch",
                column: "RegionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Region_RegionID",
                table: "Branch",
                column: "RegionID",
                principalTable: "Region",
                principalColumn: "RegionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Region_RegionID",
                table: "Branch");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropIndex(
                name: "IX_Branch_RegionID",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "Branch");
        }
    }
}
