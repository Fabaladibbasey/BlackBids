using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer(IMapper mapper) : IConsumer<AuctionCreated>
{
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("AuctionCreatedConsumer: " + context.Message.Id);
        Product product = mapper.Map<Product>(context.Message);

        //simulate exception
        if (product.Name == "error")
            throw new ArgumentException("error");

        await product.SaveAsync();
    }
}
