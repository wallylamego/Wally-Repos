using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class skuComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "SKUs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "SKUs");
        }
    }
}
