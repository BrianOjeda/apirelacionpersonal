using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    public partial class TipoDni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTipoDocumento",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "TipoDniId",
                table: "Personas",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoDniId",
                table: "Personas",
                column: "TipoDniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas",
                column: "TipoDniId",
                principalTable: "TipoDni",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "TipoDni");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TipoDniId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TipoDniId",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDocumento",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
