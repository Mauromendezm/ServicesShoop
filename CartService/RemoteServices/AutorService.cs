using CartService.RemoteInterface;
using CartService.RemoteModel;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartService.RemoteServices
{
    public class AutorService : IAutorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AutorService> _logger;

        public AutorService(IHttpClientFactory httpClientFactory, ILogger<AutorService> logger)
        {
            this._httpClientFactory = httpClientFactory;
            this._logger = logger;
        }



        public async Task<(bool result, AutorRemote autor, string msgError)> GetAutor(string autorId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Autors");
                var response = await client.GetAsync($"api/v1/Autor/{autorId}");

                if (!response.IsSuccessStatusCode)
                {
                    return (false, null, "No se pudo realizar la petición http Details: " + response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


                var result = JsonSerializer.Deserialize<AutorRemote>(content, options);

                return (true, result, "No hay errores");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, "" + e.Message);
            }
        }

    }
}
