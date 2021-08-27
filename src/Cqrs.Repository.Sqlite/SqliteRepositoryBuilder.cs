using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Cqrs.Repository.Sqlite
{
    public class SqliteRepositoryBuilder : IRepositoryBuilder
    {
        private readonly IServiceCollection services;

        public SqliteRepositoryBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public IRepositoryBuilder BuildAggregateRootRepository<T, TDbContext>()
            where T : AggregateRoot
            where TDbContext : DbContext, IAggregateRootUnitOfWork<T>
        {
            this.services.AddEntityFrameworkSqlite().AddDbContext<TDbContext>();
            this.services.AddScoped<IAggregateRootRepository<T>, SqliteAggregateRootRepository<T, TDbContext>>();
            return this;
        }

        public IRepositoryBuilder BuildReadRepository<T, TDbContext>()
            where T : ViewModelBase
            where TDbContext : DbContext, IReadSideUnitOfWork<T>
        {
            this.services.AddEntityFrameworkSqlite().AddDbContext<TDbContext>();
            this.services.AddScoped<IReadRepository<T>, SqliteReadRepository<T, TDbContext>>();
            return this;
        }
    }
}
