using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoPeligrosidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordEncriptado = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
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
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    ArchivoImagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadoConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreVulgar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoMinimo = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PesoMaximo = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    LongitudMinima = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    LongitudMaxima = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    ArchivoImagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_EstadoConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenazaEcosistema",
                columns: table => new
                {
                    AmenazasId = table.Column<int>(type: "int", nullable: false),
                    EcosistemasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazaEcosistema", x => new { x.AmenazasId, x.EcosistemasId });
                    table.ForeignKey(
                        name: "FK_AmenazaEcosistema_Amenazas_AmenazasId",
                        column: x => x.AmenazasId,
                        principalTable: "Amenazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazaEcosistema_Ecosistemas_EcosistemasId",
                        column: x => x.EcosistemasId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaPais",
                columns: table => new
                {
                    EcosistemasId = table.Column<int>(type: "int", nullable: false),
                    PaisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaPais", x => new { x.EcosistemasId, x.PaisesId });
                    table.ForeignKey(
                        name: "FK_EcosistemaPais_Ecosistemas_EcosistemasId",
                        column: x => x.EcosistemasId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaPais_Pais_PaisesId",
                        column: x => x.PaisesId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenazaEspecie",
                columns: table => new
                {
                    AmenazasId = table.Column<int>(type: "int", nullable: false),
                    EspeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazaEspecie", x => new { x.AmenazasId, x.EspeciesId });
                    table.ForeignKey(
                        name: "FK_AmenazaEspecie_Amenazas_AmenazasId",
                        column: x => x.AmenazasId,
                        principalTable: "Amenazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazaEspecie_Especies_EspeciesId",
                        column: x => x.EspeciesId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemasEspecies",
                columns: table => new
                {
                    EcosistemasId = table.Column<int>(type: "int", nullable: false),
                    EspeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemasEspecies", x => new { x.EcosistemasId, x.EspeciesId });
                    table.ForeignKey(
                        name: "FK_EcosistemasEspecies_Ecosistemas_EcosistemasId",
                        column: x => x.EcosistemasId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EcosistemasEspecies_Especies_EspeciesId",
                        column: x => x.EspeciesId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EcosistemasEspeciesPosibles",
                columns: table => new
                {
                    EcosistemasPosiblesId = table.Column<int>(type: "int", nullable: false),
                    EspeciesPosiblesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemasEspeciesPosibles", x => new { x.EcosistemasPosiblesId, x.EspeciesPosiblesId });
                    table.ForeignKey(
                        name: "FK_EcosistemasEspeciesPosibles_Ecosistemas_EcosistemasPosiblesId",
                        column: x => x.EcosistemasPosiblesId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EcosistemasEspeciesPosibles_Especies_EspeciesPosiblesId",
                        column: x => x.EspeciesPosiblesId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEcosistema_EcosistemasId",
                table: "AmenazaEcosistema",
                column: "EcosistemasId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEspecie_EspeciesId",
                table: "AmenazaEspecie",
                column: "EspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaPais_PaisesId",
                table: "EcosistemaPais",
                column: "PaisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_EstadoConservacionId",
                table: "Ecosistemas",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemasEspecies_EspeciesId",
                table: "EcosistemasEspecies",
                column: "EspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemasEspeciesPosibles_EspeciesPosiblesId",
                table: "EcosistemasEspeciesPosibles",
                column: "EspeciesPosiblesId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_NombreCientifico",
                table: "Especies",
                column: "NombreCientifico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_Nombre",
                table: "Parametros",
                column: "Nombre",
                unique: true);

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
                name: "AmenazaEcosistema");

            migrationBuilder.DropTable(
                name: "AmenazaEspecie");

            migrationBuilder.DropTable(
                name: "EcosistemaPais");

            migrationBuilder.DropTable(
                name: "EcosistemasEspecies");

            migrationBuilder.DropTable(
                name: "EcosistemasEspeciesPosibles");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "EstadoConservacion");
        }
    }
}
