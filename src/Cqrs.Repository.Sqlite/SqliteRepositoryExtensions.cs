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
    public static class SqliteRepositoryExtensions
    {
        public static IRepositoryBuilder AddSqliteRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDbConnectionSettingsProvider, SqliteDbConnectionSettingsProvider>();
            return new SqliteRepositoryBuilder(serviceCollection);
        }
    }
}
