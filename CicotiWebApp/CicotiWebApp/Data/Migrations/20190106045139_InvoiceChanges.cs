using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class InvoiceChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Accounts_CustomerAccountID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStatus_Invoices_InvoiceID",
                table: "InvoiceStatus");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceStatusID",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatus_StatusID",
                table: "InvoiceStatus",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceStatusID",
                table: "Invoices",
                column: "InvoiceStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Accounts_CustomerAccountID",
                table: "Invoices",
                column: "CustomerAccountID",
                principalTable: "Accounts",
                principalColumn: "CustomerAccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceStatus_InvoiceStatusID",
                table: "Invoices",
                column: "InvoiceStatusID",
                principalTable: "InvoiceStatus",
                principalColumn: "InvoiceStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStatus_Invoices_InvoiceID",
                table: "InvoiceStatus",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStatus_Status_StatusID",
                table: "InvoiceStatus",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Accounts_CustomerAccountID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceStatus_InvoiceStatusID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStatus_Invoices_InvoiceID",
                table: "InvoiceStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStatus_Status_StatusID",
                table: "InvoiceStatus");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceStatus_StatusID",
                table: "InvoiceStatus");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceStatusID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceStatusID",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Accounts_CustomerAccountID",
                table: "Invoices",
                column: "CustomerAccountID",
                principalTable: "Accounts",
                principalColumn: "CustomerAccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStatus_Invoices_InvoiceID",
                table: "InvoiceStatus",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
