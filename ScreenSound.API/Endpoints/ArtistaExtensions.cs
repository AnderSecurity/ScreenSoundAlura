using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class ArtistaExtensions
    {
        public static void AddEndPointsArtistas (this WebApplication app)
        {
            app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

                if (artista is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(artista));
            });

            app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
            {
                dal.Adicionar(new Artista(artistaRequest.nome, artistaRequest.bio) { FotoPerfil = artistaRequest.fotoPerfil});
                return Results.Ok();
            });

            app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
            {
                Artista? artista = dal.RecuperarPor(a => a.Id == id);

                if (artista is null)
                {
                    return Results.NotFound();
                }

                dal.Deletar(artista!);
                return Results.NoContent();
            });

            app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
            {
                Artista? artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.id);

                if (artistaAAtualizar is null)
                {
                    return Results.NotFound();
                }
                
                artistaAAtualizar.Nome = artistaRequestEdit.nome;
                artistaAAtualizar.Bio = artistaRequestEdit.bio;
                artistaAAtualizar.FotoPerfil = artistaRequestEdit.fotoPerfil;

                dal.Atualizar(artistaAAtualizar);
                return Results.Ok();
            });
        }

        private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
        {
            return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
        }

        private static ArtistaResponse EntityToResponse(Artista artista)
        {
            return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil!);
        }
    }
}
