
namespace ScreenSound.Web.Responses
{
    public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, ICollection<GeneroResponse> Generos) { }
}
