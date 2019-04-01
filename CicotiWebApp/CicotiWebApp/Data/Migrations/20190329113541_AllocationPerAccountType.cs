using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class AllocationPerAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrincipalID",
                table: "ActCostAccountPerPrinciple");

            migrationBuilder.AlterColumn<int>(
                name: "PrincipleID",
                table: "ActCostAccountPerPrinciple",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrincipleID",
                table: "ActCostAccountPerPrinciple",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PrincipalID",
                table: "ActCostAccountPerPrinciple",
                nullable: false,
                defaultValue: 0);
        }
    }
}
