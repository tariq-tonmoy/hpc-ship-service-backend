using ShipService.Infrastructure.Core;

namespace ShipService.Infrastructure.Ship.Grpc.Comm.Abstractions
{
    public interface IPrepareMessageToPublish
    {
        string PrepareMessgaePayload<TMessage>(TMessage message)
            where TMessage : IMessage;
    }
}
