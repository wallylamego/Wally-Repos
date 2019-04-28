using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class InvoiceLineAmt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InvoiceAmount",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                columns: table => new
                {
                    InvoiceLineID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKUID = table.Column<int>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    Amt = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.InvoiceLineID);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_SKUs_SKUID",
                        column: x => x.SKUID,
                        principalTable: "SKUs",
                        principalColumn: "SKUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_InvoiceID",
                table: "InvoiceLine",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_SKUID",
                table: "InvoiceLine",
                column: "SKUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "InvoiceAmount",
                table: "Invoices");
        }
    }
}
