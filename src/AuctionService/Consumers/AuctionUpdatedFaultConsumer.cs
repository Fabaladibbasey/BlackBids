using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class AuctionUpdatedFaultConsumer : IConsumer<Fault<AuctionUpdated>>
{
    public Task Consume(ConsumeContext<Fault<AuctionUpdated>> context)
    {
        var exception = context.Message.Exceptions.FirstOrDefault();

        if (exception != null && exception.ExceptionType == typeof(AuctionUpdated).FullName)
        {
            context.Publish(context.Message.Message);
        }

        Console.WriteLine("AuctionUpdatedFaultConsumer: " + exception.Message);

        return Task.CompletedTask;
    }
}
