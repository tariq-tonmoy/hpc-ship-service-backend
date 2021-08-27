using ShipService.Infrastructure.Core;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ShipService.Infrastructure.Cqrs.Repository.Contract
{
    public interface IAggregateRootRepository<T>
        where T : AggregateRoot
    {
        Task SaveAsync(T aggregateRoot);

        Task UpdateAsync(T aggregateRoot);

        Task<T> GetByIdAsync(Guid id);

        Task<bool> ExistsAsync(Guid id);

        Task<T> GetByIdAsync<TProperty>(Guid id, Expression<Func<T, TProperty>> includeExp)
            where TProperty : IEnumerable<IDomainBase>;
    }
}
