using System.Threading.Tasks;

namespace ShipService.Infrastructure.Core.Abstractions
{
    public interface IAsyncEventHandler<in TEvent>
        where TEvent : DomainEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
