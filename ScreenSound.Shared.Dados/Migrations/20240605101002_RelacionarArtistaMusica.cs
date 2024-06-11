using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class RelacionarArtistaMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "artistaId",
                table: "Musicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_artistaId",
                table: "Musicas",
                column: "artistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Artistas_artistaId",
                table: "Musicas",
                column: "artistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Artistas_artistaId",
                table: "Musicas");

            migrationBuilder.DropIndex(
                name: "IX_Musicas_artistaId",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "artistaId",
                table: "Musicas");
        }
    }
}
