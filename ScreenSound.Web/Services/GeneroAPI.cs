using ScreenSound.Web.Responses;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class GeneroAPI
{
    private readonly HttpClient _httpClient;

    public GeneroAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<GeneroResponse>?> GetGenerosAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<GeneroResponse>>("generos");
    }
    public async Task<GeneroResponse?> GetGeneroPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<GeneroResponse>($"generos/{nome}");
    }
}
