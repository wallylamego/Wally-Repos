using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class LoadsAndLoadLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VehicleID",
                table: "Loads",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "Loads",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Loads",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Loads",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoadLine",
                columns: table => new
                {
                    LoadLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoadID = table.Column<int>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true)
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
                name: "IX_Loads_UserID",
                table: "Loads",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LoadLine_InvoiceID",
                table: "LoadLine",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_LoadLine_LoadID",
                table: "LoadLine",
                column: "LoadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_AspNetUsers_UserID",
                table: "Loads",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_AspNetUsers_UserID",
                table: "Loads");

            migrationBuilder.DropTable(
                name: "LoadLine");

            migrationBuilder.DropIndex(
                name: "IX_Loads_UserID",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Loads");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleID",
                table: "Loads",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "Loads",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
