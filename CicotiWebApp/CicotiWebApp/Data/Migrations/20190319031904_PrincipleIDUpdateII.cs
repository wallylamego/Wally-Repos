using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class PrincipleIDUpdateII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrincipalID",
                table: "ActCostTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "PrincipleID",
                table: "ActCostTransactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrincipleID",
                table: "ActCostTransactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PrincipalID",
                table: "ActCostTransactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
