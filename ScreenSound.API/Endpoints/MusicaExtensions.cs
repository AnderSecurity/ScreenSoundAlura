using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicaExtensions
    {
        public static void AddEndpointMusicas(this WebApplication app)
        {
            app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                Musica? musicaRecuperada = dal.RecuperarPor(m => m.Nome == nome);

                if (musicaRecuperada is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(EntityToResponse(musicaRecuperada));
            });

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Artista> dalArtista, [FromBody] MusicaRequest musicaRequest) =>
            {
                Artista? artista = dalArtista.RecuperarPor(a => a.Id == musicaRequest.artistaId);

                if (artista is null)
                {
                    return Results.NotFound(artista);
                }

                dal.Adicionar(new Musica(musicaRequest.nome, musicaRequest.anoLancamento) { artista = artista });
                return Results.Ok();
            });

            app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
            {
                Musica? musicaADeletar = dal.RecuperarPor(m => m.Id == id);

                if (musicaADeletar is null)
                {
                    return Results.NotFound();
                }

                dal.Deletar(musicaADeletar!);
                return Results.NoContent();
            });

            app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Artista> dalArtista ,[FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                Musica? musicaAAtualizar = dal.RecuperarPor(m => m.Id == musicaRequestEdit.id);

                if (musicaAAtualizar is null)
                {
                    return Results.NotFound();
                }

                musicaAAtualizar.Nome = musicaRequestEdit.nome;
                musicaAAtualizar.AnoLancamento = musicaRequestEdit.anoLancamento;
                musicaAAtualizar.artista = dalArtista.RecuperarPor(a => a.Id == musicaRequestEdit.artistaId);

                dal.Atualizar(musicaAAtualizar!);
                return Results.Ok();
            });
        }
        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
        {
            return musicaList.Select(a => EntityToResponse(a)).ToList();
        }
        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome!, musica.artista.Id, musica.artista.Nome);
        }
    }
}
