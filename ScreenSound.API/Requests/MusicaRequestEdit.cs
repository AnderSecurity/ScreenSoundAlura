namespace ScreenSound.API.Requests
{
    public record MusicaRequestEdit(int id, string nome, int anoLancamento, int artistaId ) : MusicaRequest(nome, anoLancamento, artistaId)
    {
    }
}
