using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    public class ShipAggregateRootContextFactory : IDesignTimeDbContextFactory<ShipAggregateRootDbContext>
    {
        public ShipAggregateRootDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CommandWorkerHost"))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{args[0]}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShipAggregateRootDbContext>();
            SqliteDbConnectionSettingsProvider settingsProvider = new SqliteDbConnectionSettingsProvider(config);

            optionsBuilder.UseSqlite(config.GetSection("StateDatabaseConnectionString")?.Value);

            return new ShipAggregateRootDbContext(optionsBuilder.Options, settingsProvider);
        }
    }
}
