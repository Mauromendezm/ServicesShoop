using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Migrations
{
    public partial class MigrationSqlServerInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialLibrary",
                columns: table => new
                {
                    MaterialLibreryId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: true),
                    AutorBook = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLibrary", x => x.MaterialLibreryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialLibrary");
        }
    }
}
