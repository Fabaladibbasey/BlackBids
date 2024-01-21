using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionUpdatedConsumer(IMapper mapper) : IConsumer<AuctionUpdated>
{
    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
        // update product in search index
        var result = await DB.Update<Product>()
            .MatchID(context.Message.Id)
            .ModifyOnly(b => new
            {
                b.Name,
                b.Description,
                b.Brand,
                b.Color,
                b.Condition,
                b.Type
            }, mapper.Map<Product>(context.Message))
             .ExecuteAsync();

        if (!result.IsAcknowledged) throw new MessageException(typeof(AuctionUpdated), $"Could not update product with id: {context.Message.Id}");

    }
}
