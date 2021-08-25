using BrewStore.Shared.Services.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BrewStore.Shared.Services
{
    public class BeverageClient
    {
        private readonly HttpClient _client;

        public BeverageClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Beverage>> GetBeverages()
        {
            var response = await _client.GetAsync("/Beverages");
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Beverage>>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
        }
    }
}