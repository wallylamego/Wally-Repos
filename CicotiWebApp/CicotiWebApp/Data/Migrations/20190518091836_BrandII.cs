using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class BrandII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Principle_PrincipleID1",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_PrincipleID1",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "PrincipleID1",
                table: "Brand");

            migrationBuilder.AlterColumn<int>(
                name: "PrincipleID",
                table: "Brand",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_PrincipleID",
                table: "Brand",
                column: "PrincipleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Principle_PrincipleID",
                table: "Brand",
                column: "PrincipleID",
                principalTable: "Principle",
                principalColumn: "PrincipleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Principle_PrincipleID",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_PrincipleID",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipleID",
                table: "Brand",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PrincipleID1",
                table: "Brand",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_PrincipleID1",
                table: "Brand",
                column: "PrincipleID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Principle_PrincipleID1",
                table: "Brand",
                column: "PrincipleID1",
                principalTable: "Principle",
                principalColumn: "PrincipleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
