namespace ScreenSound.API.Requests
{
    public record GeneroRequestEdit(int id, string Nome, string Descricao) : GeneroRequest(Nome, Descricao)
    {
    }
}
