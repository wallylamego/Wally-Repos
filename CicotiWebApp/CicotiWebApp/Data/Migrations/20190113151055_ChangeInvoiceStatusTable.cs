using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ChangeInvoiceStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoadID",
                table: "InvoiceStatus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatus_LoadID",
                table: "InvoiceStatus",
                column: "LoadID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStatus_Loads_LoadID",
                table: "InvoiceStatus",
                column: "LoadID",
                principalTable: "Loads",
                principalColumn: "LoadID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStatus_Loads_LoadID",
                table: "InvoiceStatus");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceStatus_LoadID",
                table: "InvoiceStatus");

            migrationBuilder.DropColumn(
                name: "LoadID",
                table: "InvoiceStatus");
        }
    }
}
