using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class LoadStatusTakeIIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Loads_LoadStatusID",
                table: "Loads",
                column: "LoadStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_LoadStatus_LoadStatusID",
                table: "Loads",
                column: "LoadStatusID",
                principalTable: "LoadStatus",
                principalColumn: "LoadStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_LoadStatus_LoadStatusID",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_LoadStatusID",
                table: "Loads");
        }
    }
}
