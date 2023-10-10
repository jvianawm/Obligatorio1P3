using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoConservacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoConservacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAutorizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAutorizado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecieMarinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "IX_EspecieMarinas_EcosistemaId",
                table: "EspecieMarinas",
                column: "EcosistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_EcosistemaId",
                table: "Pais",
                column: "EcosistemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "EstadoConservacions");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "UsuarioAutorizado");

            migrationBuilder.DropTable(
                name: "EspecieMarinas");

            migrationBuilder.DropTable(
                name: "Ecosistemas");
        }
    }
}
