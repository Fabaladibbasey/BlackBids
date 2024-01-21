using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
{
    public async Task Consume(ConsumeContext<AuctionDeleted> context)
    {
        // delete product from search index
        var id = context.Message.Id;
        Console.WriteLine("AuctionDeletedConsumer: " + id);
        var result = await DB.DeleteAsync<Product>(id);

        if (!result.IsAcknowledged) throw new MessageException(typeof(AuctionDeleted), $"Could not delete product with id: {id}");
    }
}
