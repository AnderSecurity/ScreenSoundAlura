using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class MusicaArtistaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Artistas_ArtistaId",
                table: "Musicas");

            migrationBuilder.RenameColumn(
                name: "ArtistaId",
                table: "Musicas",
                newName: "MusicaArtistaIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Musicas_ArtistaId",
                table: "Musicas",
                newName: "IX_Musicas_MusicaArtistaIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Artistas_MusicaArtistaIdId",
                table: "Musicas",
                column: "MusicaArtistaIdId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Artistas_MusicaArtistaIdId",
                table: "Musicas");

            migrationBuilder.RenameColumn(
                name: "MusicaArtistaIdId",
                table: "Musicas",
                newName: "ArtistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Musicas_MusicaArtistaIdId",
                table: "Musicas",
                newName: "IX_Musicas_ArtistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Artistas_ArtistaId",
                table: "Musicas",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }
    }
}
