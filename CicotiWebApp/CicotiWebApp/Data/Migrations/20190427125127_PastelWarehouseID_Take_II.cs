using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class PastelWarehouseID_Take_II : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PastelWarehouseID",
                table: "Warehouse",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PastelWarehouseID",
                table: "Warehouse",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
