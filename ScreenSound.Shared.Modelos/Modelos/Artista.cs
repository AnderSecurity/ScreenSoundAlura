namespace ScreenSound.Modelos; 

public class Artista
{ 
    public int Id { get; set; }
    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio { get; set; }
    
    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    public Artista()
    {
    }

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do MusicaArtistaId {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano de Lançamento: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
Nome: {Nome}
Foto de Perfil: {FotoPerfil}
Bio: {Bio}";
    }
}