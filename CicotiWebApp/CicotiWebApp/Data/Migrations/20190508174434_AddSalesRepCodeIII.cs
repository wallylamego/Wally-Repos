using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class AddSalesRepCodeIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesRepCodeEmployeeNoLink",
                columns: table => new
                {
                    SalesRepCodeEmployeeNoLinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    SalesRepID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRepCodeEmployeeNoLink", x => x.SalesRepCodeEmployeeNoLinkID);
                    table.ForeignKey(
                        name: "FK_SalesRepCodeEmployeeNoLink_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRepCodeEmployeeNoLink_SalesReps_SalesRepID",
                        column: x => x.SalesRepID,
                        principalTable: "SalesReps",
                        principalColumn: "SalesRepID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepCodeEmployeeNoLink_EmployeeID",
                table: "SalesRepCodeEmployeeNoLink",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRepCodeEmployeeNoLink_SalesRepID",
                table: "SalesRepCodeEmployeeNoLink",
                column: "SalesRepID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesRepCodeEmployeeNoLink");
        }
    }
}
