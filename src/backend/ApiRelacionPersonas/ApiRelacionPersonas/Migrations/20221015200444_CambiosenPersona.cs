using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    public partial class CambiosenPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Nacionalidad_NacionalidadId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDniId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NacionalidadId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Nacionalidad_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId",
                principalTable: "Nacionalidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas",
                column: "TipoDniId",
                principalTable: "TipoDni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Nacionalidad_NacionalidadId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDniId",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NacionalidadId",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Nacionalidad_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId",
                principalTable: "Nacionalidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoDni_TipoDniId",
                table: "Personas",
                column: "TipoDniId",
                principalTable: "TipoDni",
                principalColumn: "Id");
        }
    }
}
