using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class migracion_inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoCons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    DescripcionCaracteristicas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadoConservacion_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspecieMarinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreVulgar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RangoPeso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangoLongitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    EcosistemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieMarinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecieMarinas_Ecosistemas_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspecieMarinas_EstadoConservacion_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EcosistemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pais_Ecosistemas_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoPeligrosidad = table.Column<int>(type: "int", nullable: false),
                    EcosistemaId = table.Column<int>(type: "int", nullable: true),
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenazas_Ecosistemas_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amenazas_EspecieMarinas_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "EspecieMarinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EcosistemaId",
                table: "Amenazas",
                column: "EcosistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_EstadoId",
                table: "Ecosistemas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecieMarinas_EcosistemaId",
                table: "EspecieMarinas",
                column: "EcosistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecieMarinas_EstadoId",
                table: "EspecieMarinas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_EcosistemaId",
                table: "Pais",
                column: "EcosistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Alias",
                table: "Usuario",
                column: "Alias",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EspecieMarinas");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "EstadoConservacion");
        }
    }
}
