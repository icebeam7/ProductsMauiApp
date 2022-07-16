using System.Text.Json;
using System.Net.Http.Json;

using ProductsApp.Models;

namespace ProductsApp.Services
{
    public class ProductsService
    {
        HttpClient httpClient;

        public ProductsService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetOnlineProducts()
        {
            var response = await httpClient.GetAsync("https://jsonkeeper.com/b/LPRG");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Product>>();

            return default;
        }

        public async Task<List<Product>> GetOfflineProducts()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("products.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<Product>>(contents);
        }
    }
}
