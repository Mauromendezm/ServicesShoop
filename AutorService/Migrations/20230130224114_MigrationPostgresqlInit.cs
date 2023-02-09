using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AutorService.Migrations
{
    public partial class MigrationPostgresqlInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorBook",
                columns: table => new
                {
                    AutorBookId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    AutorBookGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorBook", x => x.AutorBookId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    AcademicDegreeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    DegreeDate = table.Column<DateTime>(nullable: false),
                    AutorBookId = table.Column<int>(nullable: false),
                    AcademicDegreeGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegree", x => x.AcademicDegreeId);
                    table.ForeignKey(
                        name: "FK_AcademicDegree_AutorBook_AutorBookId",
                        column: x => x.AutorBookId,
                        principalTable: "AutorBook",
                        principalColumn: "AutorBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDegree_AutorBookId",
                table: "AcademicDegree",
                column: "AutorBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "AutorBook");
        }
    }
}
