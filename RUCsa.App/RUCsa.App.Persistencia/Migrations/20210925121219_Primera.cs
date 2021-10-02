using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RUCsa.App.Persistencia.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aforo = table.Column<int>(type: "int", nullable: false),
                    numero_mesas = table.Column<int>(type: "int", nullable: false),
                    personas_por_mesa = table.Column<int>(type: "int", nullable: false),
                    menu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tunos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    persona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hora_asistencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    menu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<int>(type: "int", nullable: false),
                    edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadocovid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restauranteid = table.Column<int>(type: "int", nullable: true),
                    dependencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    turno_servicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personal_Cocina_turno_servicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cubiculo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personas_Restaurantes_Restauranteid",
                        column: x => x.Restauranteid,
                        principalTable: "Restaurantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Restauranteid",
                table: "Personas",
                column: "Restauranteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
