using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Requests
{
    public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, ICollection<GeneroResponse> Generos) { }
}
