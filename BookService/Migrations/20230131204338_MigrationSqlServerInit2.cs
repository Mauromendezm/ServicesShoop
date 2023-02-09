using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Migrations
{
    public partial class MigrationSqlServerInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "MaterialLibrary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialLibrary",
                table: "MaterialLibrary",
                column: "MaterialLibreryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialLibrary",
                table: "MaterialLibrary");

            migrationBuilder.RenameTable(
                name: "MaterialLibrary",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "MaterialLibreryId");
        }
    }
}
