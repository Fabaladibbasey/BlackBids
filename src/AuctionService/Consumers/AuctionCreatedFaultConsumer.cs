using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
{
    public Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        Console.WriteLine("AuctionCreatedFaultConsumer: " + context.Message.Message.Id);

        var exception = context.Message.Exceptions.FirstOrDefault();
        if (exception != null && exception.ExceptionType == "System.ArgumentException")
        {
            context.Message.Message.Name = "corrected";
            context.Publish(context.Message.Message);
        }

        Console.WriteLine("AuctionCreatedFaultConsumer: " + context.Message.Message.Id);
        Console.WriteLine(exception.Message);
        Console.WriteLine(exception.StackTrace);

        return Task.CompletedTask;
    }
}
