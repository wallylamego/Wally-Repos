using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class LoadChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Locations_DestinationLocationID",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Locations_SourceLocationID",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_DestinationLocationID",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "DestinationLocationID",
                table: "Loads");

            migrationBuilder.RenameColumn(
                name: "SourceLocationID",
                table: "Loads",
                newName: "DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_SourceLocationID",
                table: "Loads",
                newName: "IX_Loads_DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Destinations_DestinationID",
                table: "Loads",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Destinations_DestinationID",
                table: "Loads");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "Loads",
                newName: "SourceLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_DestinationID",
                table: "Loads",
                newName: "IX_Loads_SourceLocationID");

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationID",
                table: "Loads",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loads_DestinationLocationID",
                table: "Loads",
                column: "DestinationLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Locations_DestinationLocationID",
                table: "Loads",
                column: "DestinationLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Locations_SourceLocationID",
                table: "Loads",
                column: "SourceLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
