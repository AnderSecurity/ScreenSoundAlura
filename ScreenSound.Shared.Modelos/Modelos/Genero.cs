using ScreenSound.Modelos;

namespace ScreenSound.Shared.Modelos.Modelos
{
    public class Genero
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public virtual ICollection<Musica> Musicas { get; set; }

        public Genero() { }
        public Genero(string? nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} - Descrição: {Descricao}";
        }
    }
}
