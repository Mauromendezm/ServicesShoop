using CartService.RemoteInterface;
using CartService.RemoteModel;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartService.RemoteServices
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger)
        {
            this._httpClient = httpClient;
            this._logger = logger;
        }
        public async Task<(bool result, BookRemote book, string msgError)> GetLibro(Guid libroId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/v1/Book/{libroId}");

                if (!response.IsSuccessStatusCode)
                {
                    return (false, null, "No se pudo realizar la petición http Details: " + response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


                var result = JsonSerializer.Deserialize<BookRemote>(content, options);

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
