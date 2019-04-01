using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class AddAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActCostAccountTypeID",
                table: "ActCostAccount",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActCostAccountType",
                columns: table => new
                {
                    ActCostAccountTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAccountType", x => x.ActCostAccountTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_ActCostAccountTypeID",
                table: "ActCostAccount",
                column: "ActCostAccountTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActCostAccount_ActCostAccountType_ActCostAccountTypeID",
                table: "ActCostAccount",
                column: "ActCostAccountTypeID",
                principalTable: "ActCostAccountType",
                principalColumn: "ActCostAccountTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActCostAccount_ActCostAccountType_ActCostAccountTypeID",
                table: "ActCostAccount");

            migrationBuilder.DropTable(
                name: "ActCostAccountType");

            migrationBuilder.DropIndex(
                name: "IX_ActCostAccount_ActCostAccountTypeID",
                table: "ActCostAccount");

            migrationBuilder.DropColumn(
                name: "ActCostAccountTypeID",
                table: "ActCostAccount");
        }
    }
}
