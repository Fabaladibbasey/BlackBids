using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    public async Task Consume(ConsumeContext<AuctionFinished> context)
    {
        var auction = await DB.Find<Product>().OneAsync(context.Message.AuctionId);

        if (context.Message.ProductSold)
        {
            auction.Winner = context.Message.Winner;
            auction.SoldAmount = (int)context.Message.Amount;
        }

        auction.Status = "Finished";

        await auction.SaveAsync();
    }
}