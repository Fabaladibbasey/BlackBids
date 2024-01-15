using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services;

public class AuctionServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
{
    public async Task<List<Product>> GetProductsForSearchDbAsync()
    {
        string lastUpdated = await DB.Find<Product, String>()
            .Sort(p => p.Descending(p => p.UpdatedAt))
            .Limit(1)
            .Project(p => p.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        httpClient.BaseAddress = new Uri(configuration["AuctionServiceUrl"]);
        string url = new UriBuilder(httpClient.BaseAddress)
        {
            Path = $"api/auctions",
            Query = $"date={lastUpdated}"
        }.ToString();

        return await httpClient.GetFromJsonAsync<List<Product>>(url) ?? [];
    }
}
