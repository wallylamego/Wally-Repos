using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class InvoiceChangesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceStatus_InvoiceStatusID",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceStatusID",
                table: "Invoices",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_InvoiceStatusID",
                table: "Invoices",
                newName: "IX_Invoices_StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Status_StatusID",
                table: "Invoices",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Status_StatusID",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Invoices",
                newName: "InvoiceStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_StatusID",
                table: "Invoices",
                newName: "IX_Invoices_InvoiceStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceStatus_InvoiceStatusID",
                table: "Invoices",
                column: "InvoiceStatusID",
                principalTable: "InvoiceStatus",
                principalColumn: "InvoiceStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
