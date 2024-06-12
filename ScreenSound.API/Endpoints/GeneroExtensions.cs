using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class GeneroExtensions
    {
        public static void AddEndPointsGeneros(this WebApplication app)
        {
            app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
            {
                return Results.Ok(GeneroListResponseConverter(dal.Listar()));
            });

            app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
            {
                Genero genero = dal.RecuperarPor(a => a.Nome!.ToUpper().Equals(nome.ToUpper()))!;

                if (genero is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(GeneroToResponse(genero));
            });

            app.MapPost("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequest generoRequest) =>
            {
                var genero = dal.RecuperarPor(g => g.Nome!.ToUpper().Equals(generoRequest.Nome!.ToUpper()));

                if(genero is null)
                {
                    dal.Adicionar(new Genero(generoRequest.Nome, generoRequest.Descricao));
                    return Results.Ok();
                }
                else
                {
                    return Results.Unauthorized();
                }
                
            });

            app.MapDelete("/Generos/{id}", ([FromServices] DAL<Genero> dal, int id) =>
            {
                Genero? genero = dal.RecuperarPor(g => g.Id == id);

                if (genero is null)
                {
                    return Results.NotFound();
                }

                dal.Deletar(genero!);
                return Results.NoContent();
            });

            app.MapPut("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequestEdit generoRequestEdit) =>
            {
                Genero? generoAAtualizar = dal.RecuperarPor(g => g.Id == generoRequestEdit.id);

                if (generoAAtualizar is null)
                {
                    return Results.NotFound();
                }

                generoAAtualizar.Nome = generoRequestEdit.Nome;
                generoAAtualizar.Descricao = generoRequestEdit.Descricao;

                dal.Atualizar(generoAAtualizar);
                return Results.Ok();
            });
        }

        internal static ICollection<GeneroResponse> GeneroListResponseConverter(IEnumerable<Genero> generos)
        {
            return generos.Select(a => GeneroToResponse(a)).ToList();
        }

        internal static GeneroResponse GeneroToResponse(Genero genero)
        {
            return new GeneroResponse(genero.Id, genero.Nome!, genero.Descricao!);
        }
    }
}
