using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class AuctionDeletedFaultConsumer : IConsumer<Fault<AuctionDeleted>>
{
    public Task Consume(ConsumeContext<Fault<AuctionDeleted>> context)
    {
        var exception = context.Message.Exceptions.FirstOrDefault();

        if (exception != null && exception.ExceptionType == typeof(AuctionDeleted).FullName)
        {
            context.Publish(context.Message.Message);
        }

        Console.WriteLine("AuctionDeletedFaultConsumer: " + exception.Message);

        return Task.CompletedTask;

    }
}
