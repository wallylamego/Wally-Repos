using Microsoft.EntityFrameworkCore.Migrations;

namespace CicotiWebApp.Data.Migrations
{
    public partial class MakeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Model_ModelID",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriveType",
                table: "DriveType");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "FuelType",
                newName: "FuelTypes");

            migrationBuilder.RenameTable(
                name: "DriveType",
                newName: "DriveTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Model_MakeID",
                table: "Models",
                newName: "IX_Models_MakeID");

            migrationBuilder.RenameIndex(
                name: "IX_Model_FuelTypeID",
                table: "Models",
                newName: "IX_Models_FuelTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Model_DriveTypeID",
                table: "Models",
                newName: "IX_Models_DriveTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "ModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes",
                column: "FuelTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriveTypes",
                table: "DriveTypes",
                column: "DriveTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_DriveTypes_DriveTypeID",
                table: "Models",
                column: "DriveTypeID",
                principalTable: "DriveTypes",
                principalColumn: "DriveTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_FuelTypes_FuelTypeID",
                table: "Models",
                column: "FuelTypeID",
                principalTable: "FuelTypes",
                principalColumn: "FuelTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Make_MakeID",
                table: "Models",
                column: "MakeID",
                principalTable: "Make",
                principalColumn: "MakeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelID",
                table: "Vehicles",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_DriveTypes_DriveTypeID",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_FuelTypes_FuelTypeID",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Make_MakeID",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelID",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriveTypes",
                table: "DriveTypes");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "FuelTypes",
                newName: "FuelType");

            migrationBuilder.RenameTable(
                name: "DriveTypes",
                newName: "DriveType");

            migrationBuilder.RenameIndex(
                name: "IX_Models_MakeID",
                table: "Model",
                newName: "IX_Model_MakeID");

            migrationBuilder.RenameIndex(
                name: "IX_Models_FuelTypeID",
                table: "Model",
                newName: "IX_Model_FuelTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Models_DriveTypeID",
                table: "Model",
                newName: "IX_Model_DriveTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "ModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType",
                column: "FuelTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriveType",
                table: "DriveType",
                column: "DriveTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_DriveType_DriveTypeID",
                table: "Model",
                column: "DriveTypeID",
                principalTable: "DriveType",
                principalColumn: "DriveTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_FuelType_FuelTypeID",
                table: "Model",
                column: "FuelTypeID",
                principalTable: "FuelType",
                principalColumn: "FuelTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Make_MakeID",
                table: "Model",
                column: "MakeID",
                principalTable: "Make",
                principalColumn: "MakeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Model_ModelID",
                table: "Vehicles",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
