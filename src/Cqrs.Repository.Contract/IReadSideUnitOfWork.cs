using ShipService.Infrastructure.Core;

namespace ShipService.Infrastructure.Cqrs.Repository.Contract
{
    public interface IReadSideUnitOfWork<out T> : IUnitOfWork
        where T : ViewModelBase
    {
    }
}
