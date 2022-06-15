using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rihal.DataAccess.Migrations
{
    public partial class initialaRihalbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    class_name = table.Column<string>(type: "TEXT", nullable: false),
                    creation_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    creation_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    class_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    country_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    creation_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_classes_class_Id",
                        column: x => x.class_Id,
                        principalTable: "classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_countries_country_Id",
                        column: x => x.country_Id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_class_Id",
                table: "students",
                column: "class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_students_country_Id",
                table: "students",
                column: "country_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
