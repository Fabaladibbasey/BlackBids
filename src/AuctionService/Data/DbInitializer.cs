using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static readonly Random gen = new();

    private static DateTime GetRandomCreatedDate()
    {
        DateTime start = DateTime.UtcNow.AddMinutes(-30);
        int range = (int)(DateTime.UtcNow - start).TotalMinutes;
        return start.AddMinutes(gen.Next(range + 1));
    }

    private static DateTime GetRandomEndDate()
    {
        DateTime start = DateTime.UtcNow;
        int range = 40 + gen.Next(60 * 24 * 30);
        return start.AddMinutes(range);
    }

    private static async void SeedData(AuctionDbContext context)
    {
        await context.Database.MigrateAsync();

        if (context.Auctions.Any())
        {
            return;
        }

        var auctions = new List<Auction>
        {
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddHours(3),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Fender Stratocaster",
                    Description = "A guitar",
                    Brand = "Fender",
                    Type = "Electric",
                    Condition = "Second Hand",
                    Color = "Red",
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/04/12/19/35/guitar-30315_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000000,
                Seller = "ali",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ford GT",
                    Description = "A car",
                    Brand = "Ford",
                    Type = "Car",
                    Condition = "New",
                    Color = "Blue",
                    ImageUrl = "https://cdn.pixabay.com/photo/2024/08/07/08/41/sports-car-8951286_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 10000,
                Seller = "bob",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Rolex Submariner",
                    Description = "A watch",
                    Brand = "Rolex",
                    Type = "Watch",
                    Condition = "New",
                    Color = "Black",
                    ImageUrl = "https://cdn.pixabay.com/photo/2013/07/12/15/50/ticker-150395_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000,
                Seller = "tom",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple iPhone 12",
                    Description = "A phone",
                    Brand = "Apple",
                    Type = "Phone",
                    Condition = "second hand",
                    Color = "Green",
                    ImageUrl = "https://cdn.pixabay.com/photo/2020/12/14/09/46/smartphone-5830473_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 2000,
                Seller = "peter",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple MacBook Pro",
                    Description = "A laptop",
                    Brand = "Apple",
                    Type = "Laptop",
                    Condition = "New",
                    Color = "Silver",
                    ImageUrl = "https://cdn.pixabay.com/photo/2019/07/21/21/32/laptop-4353711_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.ReserveNotMet,
                ReservePrice = 10000,
                Seller = "john",
                AuctionEnd = DateTime.UtcNow.AddDays(-2),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Mercedes SLK",
                    Description = "A car",
                    Brand = "Mercedes",
                    Type = "Car",
                    Condition = "New",
                    Color = "Black",
                    ImageUrl = "https://cdn.pixabay.com/photo/2013/07/12/13/21/daimler-146887_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Finished,
                ReservePrice = 1000000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(-35),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "House",
                    Description = "A house",
                    Brand = "House",
                    Type = "House",
                    Condition = "New",
                    Color = "Cream",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/06/01/17/43/house-1429409_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000000,
                Seller = "alice",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ferrari F-430",
                    Description = "A car",
                    Brand = "Ferrari",
                    Type = "Car",
                    Condition = "New",
                    Color = "Red",
                    ImageUrl = "https://cdn.pixabay.com/photo/2014/03/24/17/17/racing-car-295307_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 10000,
                Seller = "alice",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Rolex Submariner",
                    Description = "A watch",
                    Brand = "Rolex",
                    Type = "Watch",
                    Condition = "New",
                    Color = "Magneta",
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/04/26/18/44/watch-42803_1280.png"
                }
            },
            new()
            {
                CreatedAt = GetRandomCreatedDate(),
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000000,
                Seller = "john",
                AuctionEnd = GetRandomEndDate(),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Pool House",
                    Description = "A house",
                    Brand = "House",
                    Type = "House",
                    Condition = "New",
                    Color = "Yellow",
                    ImageUrl = "https://cdn.pixabay.com/photo/2019/06/13/19/10/pool-house-4272310_1280.jpg"
                }
            },

        };

        await context.Auctions.AddRangeAsync(auctions);
        await context.SaveChangesAsync();

    }
}
