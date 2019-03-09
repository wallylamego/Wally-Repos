using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class LocationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationID",
                table: "Loads",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoadStatusID",
                table: "Loads",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceLocationID",
                table: "Loads",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoadStatus",
                columns: table => new
                {
                    LoadStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadStatus", x => x.LoadStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loads_DestinationLocationID",
                table: "Loads",
                column: "DestinationLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_SourceLocationID",
                table: "Loads",
                column: "SourceLocationID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Locations_DestinationLocationID",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Locations_SourceLocationID",
                table: "Loads");

            migrationBuilder.DropTable(
                name: "LoadStatus");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Loads_DestinationLocationID",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_SourceLocationID",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "DestinationLocationID",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "LoadStatusID",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "SourceLocationID",
                table: "Loads");
        }
    }
}
