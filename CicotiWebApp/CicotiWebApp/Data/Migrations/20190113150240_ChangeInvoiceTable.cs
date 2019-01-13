using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ChangeInvoiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadLine",
                columns: table => new
                {
                    LoadLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceID = table.Column<int>(nullable: true),
                    LoadID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadLine", x => x.LoadLineID);
                    table.ForeignKey(
                        name: "FK_LoadLine_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadLine_Loads_LoadID",
                        column: x => x.LoadID,
                        principalTable: "Loads",
                        principalColumn: "LoadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadLine_InvoiceID",
                table: "LoadLine",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_LoadLine_LoadID",
                table: "LoadLine",
                column: "LoadID");
        }
    }
}
