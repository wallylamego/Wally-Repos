using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class InvoiceProductTypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceProductTypeID",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceProductType",
                columns: table => new
                {
                    InvoiceProductTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProductType", x => x.InvoiceProductTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceProductTypeID",
                table: "Invoices",
                column: "InvoiceProductTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceProductType_InvoiceProductTypeID",
                table: "Invoices",
                column: "InvoiceProductTypeID",
                principalTable: "InvoiceProductType",
                principalColumn: "InvoiceProductTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceProductType_InvoiceProductTypeID",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceProductType");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceProductTypeID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceProductTypeID",
                table: "Invoices");
        }
    }
}
