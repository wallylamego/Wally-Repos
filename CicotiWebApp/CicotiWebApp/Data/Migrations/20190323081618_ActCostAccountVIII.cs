using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccountVIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "ActCostAccountBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "ActCostAccountBalance",
                nullable: false,
                defaultValue: 0);
        }
    }
}
