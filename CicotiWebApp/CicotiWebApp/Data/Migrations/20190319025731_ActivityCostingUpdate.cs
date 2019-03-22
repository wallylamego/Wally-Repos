using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActivityCostingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodID",
                table: "ActCostTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "ActCostPeriodID",
                table: "ActCostTransactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ActCostPeriodID",
                table: "ActCostTransactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PeriodID",
                table: "ActCostTransactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
