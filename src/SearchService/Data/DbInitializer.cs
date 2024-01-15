using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data;

public class DbInitializer()
{
    public static async Task InitializeAsync(WebApplication app)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Product>()
            .Key(p => p.Name, KeyType.Text)
            .Key(p => p.Description, KeyType.Text)
            .Key(p => p.Color, KeyType.Text)
            .Key(p => p.Type, KeyType.Text)
            .Key(p => p.Brand, KeyType.Text)
            .Key(p => p.Condition, KeyType.Text)
            .Key(p => p.Status, KeyType.Text)
            .Key(p => p.Seller, KeyType.Text)
            .Key(p => p.Winner, KeyType.Text)
            .Key(p => p.ImageUrl, KeyType.Text)
            .Key(p => p.CreatedAt, KeyType.Ascending)
            .Key(p => p.UpdatedAt, KeyType.Ascending)
            .Key(p => p.AuctionEnd, KeyType.Ascending)
            .Key(p => p.SoldAmount, KeyType.Ascending)
            .Key(p => p.CurrentHighBid, KeyType.Ascending)
            .Key(p => p.ReservePrice, KeyType.Ascending)
            .CreateAsync();

        // var count = await DB.Queryable<Product>().CountAsync();
        // if (count == 0)
        // {
        //     Console.WriteLine("No data found in the database, inserting some data...");

        //     // insert some data to the database from the json file
        //     var products = await File.ReadAllTextAsync("Data/products.json");

        //     options.PropertyNameCaseInsensitive = true;

        //     var productsList = JsonSerializer.Deserialize<List<Product>>(products, options);
        //     await DB.InsertAsync(productsList);
        //     await DB.SaveAsync(productsList);
        // }

        // get auction service client from the DI container
        using var scope = app.Services.CreateScope();
        var auctionServiceHttpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();

        var products = await auctionServiceHttpClient.GetProductsForSearchDbAsync();

        Console.WriteLine(products.Count + " products returned from the auction service");

        if (products.Count > 0)
        {
            await DB.InsertAsync(products);
            await DB.SaveAsync(products);
        }

    }

}

