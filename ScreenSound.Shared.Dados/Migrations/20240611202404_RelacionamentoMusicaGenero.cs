using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoMusicaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Artistas_artistaId",
                table: "Musicas");

            migrationBuilder.RenameColumn(
                name: "artistaId",
                table: "Musicas",
                newName: "ArtistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Musicas_artistaId",
                table: "Musicas",
                newName: "IX_Musicas_ArtistaId");

            migrationBuilder.CreateTable(
                name: "GeneroMusica",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    MusicasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroMusica", x => new { x.GenerosId, x.MusicasId });
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Musicas_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroMusica_MusicasId",
                table: "GeneroMusica",
                column: "MusicasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Artistas_ArtistaId",
                table: "Musicas",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Artistas_ArtistaId",
                table: "Musicas");

            migrationBuilder.DropTable(
                name: "GeneroMusica");

            migrationBuilder.RenameColumn(
                name: "ArtistaId",
                table: "Musicas",
                newName: "artistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Musicas_ArtistaId",
                table: "Musicas",
                newName: "IX_Musicas_artistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Artistas_artistaId",
                table: "Musicas",
                column: "artistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }
    }
}
