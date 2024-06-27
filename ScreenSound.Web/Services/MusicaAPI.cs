using ScreenSound.Web.Requests;
using ScreenSound.Web.Responses;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class MusicaAPI
    {
        private readonly HttpClient _httpClient;

        public MusicaAPI (IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
        }

        public async Task AddMusicaAsync(MusicaRequest musica)
        {
            await _httpClient.PostAsJsonAsync("musicas", musica);
        }
    }
}
