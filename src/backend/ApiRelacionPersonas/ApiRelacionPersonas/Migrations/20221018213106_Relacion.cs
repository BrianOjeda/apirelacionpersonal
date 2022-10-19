using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    public partial class Relacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId_Padre = table.Column<int>(type: "int", nullable: false),
                    PersonaId_Hijo = table.Column<int>(type: "int", nullable: false),
                    PersonaPadreId = table.Column<int>(type: "int", nullable: true),
                    PersonaHijoId = table.Column<int>(type: "int", nullable: true),
                    TipoRelacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relaciones_Personas_PersonaHijoId",
                        column: x => x.PersonaHijoId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Relaciones_Personas_PersonaPadreId",
                        column: x => x.PersonaPadreId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoRelacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRelacions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relaciones_PersonaHijoId",
                table: "Relaciones",
                column: "PersonaHijoId");

            migrationBuilder.CreateIndex(
                name: "IX_Relaciones_PersonaPadreId",
                table: "Relaciones",
                column: "PersonaPadreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relaciones");

            migrationBuilder.DropTable(
                name: "TipoRelacions");
        }
    }
}
