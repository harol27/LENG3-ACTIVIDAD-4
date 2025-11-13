using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad5LengProg3.Migrations
{
    /// <inheritdoc />
    public partial class RelacionesEstudianteCarreraRecinto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Recinto",
                table: "Estudiantes");

            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecintoId",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CarreraId",
                table: "Estudiantes",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_RecintoId",
                table: "Estudiantes",
                column: "RecintoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Carreras_CarreraId",
                table: "Estudiantes",
                column: "CarreraId",
                principalTable: "Carreras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Recintos_RecintoId",
                table: "Estudiantes",
                column: "RecintoId",
                principalTable: "Recintos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Carreras_CarreraId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Recintos_RecintoId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_CarreraId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_RecintoId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "RecintoId",
                table: "Estudiantes");

            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recinto",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
