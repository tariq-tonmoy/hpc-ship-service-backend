using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Cqrs.Repository.Contract
{
    public interface IReadRepository<T>
        where T : ViewModelBase
    {
        Task SaveAsync(T viewModel);

        Task UpdateAsync(T viewModel);

        IQueryable<T> GetByFilter(Expression<Func<T, bool>> dataFilters);

        Task DeleteAsync(T viewModel);
    }
}
