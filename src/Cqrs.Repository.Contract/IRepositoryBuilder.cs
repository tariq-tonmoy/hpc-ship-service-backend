using ShipService.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Cqrs.Repository.Contract
{
    public interface IRepositoryBuilder
    {
        IRepositoryBuilder BuildReadRepository<T, TDbContext>()
            where T : ViewModelBase
            where TDbContext : DbContext, IReadSideUnitOfWork<T>;

        IRepositoryBuilder BuildAggregateRootRepository<T, TDbContext>()
            where T : AggregateRoot
            where TDbContext : DbContext, IAggregateRootUnitOfWork<T>;
    }
}
