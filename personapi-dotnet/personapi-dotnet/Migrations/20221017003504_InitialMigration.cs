using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personapi_dotnet.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    cc = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    apellido = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    genero = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persona__3213666D7BB192F1", x => x.cc);
                });

            migrationBuilder.CreateTable(
                name: "Profesion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nom = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    dest = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    num = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    duenio = table.Column<int>(type: "int", nullable: false),
                    oper = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Telefono__1EE0396B24860D5B", x => new { x.num, x.duenio });
                    table.ForeignKey(
                        name: "FK__Telefono__duenio__2E1BDC42",
                        column: x => x.duenio,
                        principalTable: "Persona",
                        principalColumn: "cc");
                });

            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    id_prof = table.Column<int>(type: "int", nullable: false),
                    cc_per = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    univer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estudios__FB3F71A60D66D208", x => new { x.id_prof, x.cc_per });
                    table.ForeignKey(
                        name: "FK__Estudios__cc_per__2B3F6F97",
                        column: x => x.cc_per,
                        principalTable: "Persona",
                        principalColumn: "cc");
                    table.ForeignKey(
                        name: "FK__Estudios__id_pro__2A4B4B5E",
                        column: x => x.id_prof,
                        principalTable: "Profesion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_cc_per",
                table: "Estudios",
                column: "cc_per");

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_duenio",
                table: "Telefono",
                column: "duenio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Profesion");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
