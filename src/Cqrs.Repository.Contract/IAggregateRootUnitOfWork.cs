using ShipService.Infrastructure.Core;

namespace ShipService.Infrastructure.Cqrs.Repository.Contract
{
    public interface IAggregateRootUnitOfWork<out T> : IUnitOfWork
        where T : AggregateRoot
    {
    }
}
