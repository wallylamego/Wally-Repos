using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class Warehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WarehouseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_WarehouseID",
                table: "Invoices",
                column: "WarehouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Warehouse_WarehouseID",
                table: "Invoices",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Warehouse_WarehouseID",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_WarehouseID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "WarehouseID",
                table: "Invoices");
        }
    }
}
