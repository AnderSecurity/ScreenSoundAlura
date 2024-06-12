using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Responses
{
    public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, ICollection<GeneroResponse> Generos) { }
}
