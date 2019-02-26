using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class MakeModelSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriveTypeID",
                table: "Model",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelTypeID",
                table: "Model",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MakeID",
                table: "Model",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfWheels",
                table: "Model",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DriveType",
                columns: table => new
                {
                    DriveTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveType", x => x.DriveTypeID);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    FuelTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.FuelTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model_DriveTypeID",
                table: "Model",
                column: "DriveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Model_FuelTypeID",
                table: "Model",
                column: "FuelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Model_MakeID",
                table: "Model",
                column: "MakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_DriveType_DriveTypeID",
                table: "Model",
                column: "DriveTypeID",
                principalTable: "DriveType",
                principalColumn: "DriveTypeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_FuelType_FuelTypeID",
                table: "Model",
                column: "FuelTypeID",
                principalTable: "FuelType",
                principalColumn: "FuelTypeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Make_MakeID",
                table: "Model",
                column: "MakeID",
                principalTable: "Make",
                principalColumn: "MakeID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_DriveType_DriveTypeID",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_FuelType_FuelTypeID",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_Make_MakeID",
                table: "Model");

            migrationBuilder.DropTable(
                name: "DriveType");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropIndex(
                name: "IX_Model_DriveTypeID",
                table: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Model_FuelTypeID",
                table: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Model_MakeID",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "DriveTypeID",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "FuelTypeID",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "NoOfWheels",
                table: "Model");
        }
    }
}
