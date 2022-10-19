using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    public partial class Sexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SexoId",
                table: "Personas",
                column: "SexoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Sexo_SexoId",
                table: "Personas",
                column: "SexoId",
                principalTable: "Sexo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Sexo_SexoId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropIndex(
                name: "IX_Personas_SexoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Personas");
        }
    }
}
