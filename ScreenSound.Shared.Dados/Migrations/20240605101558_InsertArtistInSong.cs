using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class InsertArtistInSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Musicas Set ArtistaId = 1 where Id = 1");
            migrationBuilder.Sql("Update Musicas Set ArtistaId = 2 where Id = 2");
            migrationBuilder.Sql("Update Musicas Set ArtistaId = 2 where Id = 3");
            migrationBuilder.Sql("Update Musicas Set ArtistaId = 3 where Id = 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Musicas Set ArtistaId = null where Id = 1");
            migrationBuilder.Sql("Update Musicas Set ArtistaId = null where Id = 2");
            migrationBuilder.Sql("Update Musicas Set ArtistaId = null where Id = 3");
            migrationBuilder.Sql("Update Musicas Set ArtistaId = null where Id = 4");
        }
    }
}
