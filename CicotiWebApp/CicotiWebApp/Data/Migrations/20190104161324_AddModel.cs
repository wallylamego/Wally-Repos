using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobDescriptionID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobDescription",
                columns: table => new
                {
                    JobDescriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescription", x => x.JobDescriptionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobDescriptionID",
                table: "Employee",
                column: "JobDescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobDescription_JobDescriptionID",
                table: "Employee",
                column: "JobDescriptionID",
                principalTable: "JobDescription",
                principalColumn: "JobDescriptionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobDescription_JobDescriptionID",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "JobDescription");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobDescriptionID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobDescriptionID",
                table: "Employee");
        }
    }
}
