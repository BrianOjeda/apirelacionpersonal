using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    public partial class TipoDniATipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "TipoDni");

            migrationBuilder.RenameColumn(
                name: "TipoDniId",
                table: "Personas",
                newName: "TipoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_TipoDniId",
                table: "Personas",
                newName: "IX_Personas_TipoDocumentoId");

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoDocumento_TipoDocumentoId",
                table: "Personas",
                column: "TipoDocumentoId",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoDocumento_TipoDocumentoId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.RenameColumn(
                name: "TipoDocumentoId",
                table: "Personas",
                newName: "TipoDniId");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_TipoDocumentoId",
                table: "Personas",
                newName: "IX_Personas_TipoDniId");

            migrationBuilder.CreateTable(
                name: "TipoDni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDni", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas",
                column: "TipoDniId",
                principalTable: "TipoDni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
