using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comidas.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComidasRapidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComidasRapidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComidasPersonas",
                columns: table => new
                {
                    ComidaRapidaId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    ComidasRapidasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComidasPersonas", x => new { x.ComidaRapidaId, x.PersonaId });
                    table.ForeignKey(
                        name: "FK_ComidasPersonas_ComidasRapidas_ComidasRapidasId",
                        column: x => x.ComidasRapidasId,
                        principalTable: "ComidasRapidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComidasPersonas_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComidasPersonas_ComidasRapidasId",
                table: "ComidasPersonas",
                column: "ComidasRapidasId");

            migrationBuilder.CreateIndex(
                name: "IX_ComidasPersonas_PersonaId",
                table: "ComidasPersonas",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComidasPersonas");

            migrationBuilder.DropTable(
                name: "ComidasRapidas");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
