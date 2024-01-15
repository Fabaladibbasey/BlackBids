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
                Id = Guid.NewGuid(),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Fender Stratocaster",
                    Description = "A guitar",
                    Brand = "Fender",
                    Type = "Electric",
                    Condition = "New",
                    Color = "Red",
                    // take image from pixabay e.g. https://pixabay.com/photos/guitar-classical-guitar-acoustic-1209016/
                    ImageUrl = "https://pixabay.com/photos/guitar-classical-guitar-acoustic-1209016/"
                }
            },
            // 2 Ford GT
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000000,
                Seller = "ali",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ford GT",
                    Description = "A car",
                    Brand = "Ford",
                    Type = "Car",
                    Condition = "New",
                    Color = "Blue",
                    // take image from pixabay e.g. https://pixabay.com/photos/ford-gt-2017-ford-gt-blue-automotive-2486097/
                    ImageUrl = "https://pixabay.com/photos/ford-gt-2017-ford-gt-blue-automotive-2486097/"
                }
            },

            // 3 Rolex Submariner
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 10000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Rolex Submariner",
                    Description = "A watch",
                    Brand = "Rolex",
                    Type = "Watch",
                    Condition = "New",
                    Color = "Black",
                    // take image from pixabay e.g. https://pixabay.com/photos/rolex-submariner-watch-time-luxury-2593464/
                    ImageUrl = "https://pixabay.com/photos/rolex-submariner-watch-time-luxury-2593464/"
                }
            },

            // 4 Apple iPhone 12
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple iPhone 12",
                    Description = "A phone",
                    Brand = "Apple",
                    Type = "Phone",
                    Condition = "New",
                    Color = "Black",
                    // take image from pixabay e.g. https://pixabay.com/photos/iphone-12-iphone-12-pro-iphone-12-5725727/
                    ImageUrl = "https://pixabay.com/photos/iphone-12-iphone-12-pro-iphone-12-5725727/"
                }
            },

            // 5 Apple MacBook Pro
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 2000,
                Seller = "peter",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple MacBook Pro",
                    Description = "A laptop",
                    Brand = "Apple",
                    Type = "Laptop",
                    Condition = "New",
                    Color = "Silver",
                    // take image from pixabay e.g. https://pixabay.com/photos/macbook-pro-laptop-apple-macbook-1853306/
                    ImageUrl = "https://pixabay.com/photos/macbook-pro-laptop-apple-macbook-1853306/"
                }
            },

            // 6 Mercedes SLK with reserve not met
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.ReserveNotMet,
                ReservePrice = 10000,
                Seller = "john",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Mercedes SLK",
                    Description = "A car",
                    Brand = "Mercedes",
                    Type = "Car",
                    Condition = "New",
                    Color = "Silver",
                    // take image from pixabay e.g. https://pixabay.com/photos/mercedes-slk-mercedes-benz-slk-230-1208271/
                    ImageUrl = "https://pixabay.com/photos/mercedes-slk-mercedes-benz-slk-230-1208271/"
                }
            },

            // 7 house with finished auction created by bob
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Finished,
                ReservePrice = 1000000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "House",
                    Description = "A house",
                    Brand = "House",
                    Type = "House",
                    Condition = "New",
                    Color = "White",
                    // take image from pixabay e.g. https://pixabay.com/photos/house-home-property-residential-498271/
                    ImageUrl = "https://pixabay.com/photos/house-home-property-residential-498271/"
                }
            },

            // 8 Ferrari F-430 live auction created by alice
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ferrari F-430",
                    Description = "A car",
                    Brand = "Ferrari",
                    Type = "Car",
                    Condition = "New",
                    Color = "Red",
                    // take image from pixabay e.g. https://pixabay.com/photos/ferrari-f-430-ferrari-f430-f430-1208270/
                    ImageUrl = "https://pixabay.com/photos/ferrari-f-430-ferrari-f430-f430-1208270/"
                }
            },

            // 9 Rolex Submariner live auction created by alice
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 10000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Rolex Submariner",
                    Description = "A watch",
                    Brand = "Rolex",
                    Type = "Watch",
                    Condition = "New",
                    Color = "Black",
                    // take image from pixabay e.g. https://pixabay.com/photos/rolex-submariner-watch-time-luxury-2593464/
                    ImageUrl = "https://pixabay.com/photos/rolex-submariner-watch-time-luxury-2593464/"
                }
            },

            // 10 house live auction created by john
            new()
            {
                Id = Guid.NewGuid(),
                Status = Status.Live,
                ReservePrice = 1000000,
                Seller = "john",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "House",
                    Description = "A house",
                    Brand = "House",
                    Type = "House",
                    Condition = "New",
                    Color = "White",
                    // take image from pixabay e.g. https://pixabay.com/photos/house-home-property-residential-498271/
                    ImageUrl = "https://pixabay.com/photos/house-home-property-residential-498271/"
                }
            },

        };

        await context.Auctions.AddRangeAsync(auctions);
        await context.SaveChangesAsync();

    }
}
