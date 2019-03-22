using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class ActCostAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActCostAccountBalance",
                columns: table => new
                {
                    ActCostAccountBalanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: false),
                    PeriodID = table.Column<int>(nullable: false),
                    YTD = table.Column<double>(nullable: false),
                    Movement = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAccountBalance", x => x.ActCostAccountBalanceID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostCategory",
                columns: table => new
                {
                    ActCostCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostCategory", x => x.ActCostCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ActCostAccount",
                columns: table => new
                {
                    ActCostAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountNo = table.Column<string>(nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ActCostCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActCostAccount", x => x.ActCostAccountID);
                    table.ForeignKey(
                        name: "FK_ActCostAccount_ActCostCategory_ActCostCategoryID",
                        column: x => x.ActCostCategoryID,
                        principalTable: "ActCostCategory",
                        principalColumn: "ActCostCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActCostAccount_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActSubCostCategory",
                columns: table => new
                {
                    ActCostSubCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    ActCostCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActSubCostCategory", x => x.ActCostSubCategoryID);
                    table.ForeignKey(
                        name: "FK_ActSubCostCategory_ActCostCategory_ActCostCategoryID",
                        column: x => x.ActCostCategoryID,
                        principalTable: "ActCostCategory",
                        principalColumn: "ActCostCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_ActCostCategoryID",
                table: "ActCostAccount",
                column: "ActCostCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ActCostAccount_BranchID",
                table: "ActCostAccount",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_ActSubCostCategory_ActCostCategoryID",
                table: "ActSubCostCategory",
                column: "ActCostCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActCostAccount");

            migrationBuilder.DropTable(
                name: "ActCostAccountBalance");

            migrationBuilder.DropTable(
                name: "ActSubCostCategory");

            migrationBuilder.DropTable(
                name: "ActCostCategory");
        }
    }
}
