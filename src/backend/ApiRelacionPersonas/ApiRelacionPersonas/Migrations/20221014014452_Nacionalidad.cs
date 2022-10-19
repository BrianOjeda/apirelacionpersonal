using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    public partial class Nacionalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NacionalidadId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nacionalidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Nacionalidad_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId",
                principalTable: "Nacionalidad",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Nacionalidad_NacionalidadId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NacionalidadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NacionalidadId",
                table: "Personas");
        }
    }
}
