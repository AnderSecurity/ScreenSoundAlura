namespace ScreenSound.Modelos;

public class Musica
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int? AnoLancamento { get; set; }
    public virtual Artista? artista { get; set; }

    public Musica(string nome)
    {
        this.Nome = nome;
    }

    public Musica(string nome, int anoLancamento)
    {
        this.Nome = nome;
        this.AnoLancamento = anoLancamento;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}