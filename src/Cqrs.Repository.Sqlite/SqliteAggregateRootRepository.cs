using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace ShipService.Infrastructure.Cqrs.Repository.Sqlite
{
    internal class SqliteAggregateRootRepository<T, TDbContext> : IAggregateRootRepository<T>
        where T : AggregateRoot
        where TDbContext : DbContext, IAggregateRootUnitOfWork<T>
    {
        private readonly TDbContext dbContext;

        public SqliteAggregateRootRepository(TDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Database.Migrate();
        }

        public async Task<T> GetByIdAsync<TProperty>(Guid id, Expression<Func<T, TProperty>> includeExp)
            where TProperty : IEnumerable<IDomainBase>
        {
            return await dbContext.Set<T>().Include(includeExp).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await dbContext.Set<T>().AnyAsync(x => x.Id == id);
        }

        public async Task SaveAsync(T aggregateRoot)
        {
            if (aggregateRoot.DomainEvents.Any(x => x is BusinessRuleViolatedEvent) == false)
            {
                var entityEntry = dbContext.Set<T>().Add(aggregateRoot);
                await dbContext.SaveChangesAsync();
                entityEntry.State = EntityState.Detached;
            }
        }

        public async Task UpdateAsync(T aggregateRoot)
        {
            if (aggregateRoot.DomainEvents.Any(x => x is BusinessRuleViolatedEvent) == false)
            {
                dbContext.Set<T>().Update(aggregateRoot);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
