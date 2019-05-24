using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "SKUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipleDescription",
                table: "SKUs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    PrincipleID = table.Column<string>(nullable: true),
                    PrincipleID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                    table.ForeignKey(
                        name: "FK_Brand_Principle_PrincipleID1",
                        column: x => x.PrincipleID1,
                        principalTable: "Principle",
                        principalColumn: "PrincipleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SKUs_BrandID",
                table: "SKUs",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_PrincipleID1",
                table: "Brand",
                column: "PrincipleID1");

            migrationBuilder.AddForeignKey(
                name: "FK_SKUs_Brand_BrandID",
                table: "SKUs",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SKUs_Brand_BrandID",
                table: "SKUs");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_SKUs_BrandID",
                table: "SKUs");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "SKUs");

            migrationBuilder.DropColumn(
                name: "PrincipleDescription",
                table: "SKUs");
        }
    }
}
