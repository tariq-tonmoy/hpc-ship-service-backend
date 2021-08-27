using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    public class ShipViewModelContextFactory : IDesignTimeDbContextFactory<ShipViewModelDbContext>
    {
        public ShipViewModelDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EventWorkerHost"))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{args[0]}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShipViewModelDbContext>();
            SqliteDbConnectionSettingsProvider settingsProvider = new SqliteDbConnectionSettingsProvider(config);

            optionsBuilder.UseSqlite(config.GetSection("ReadDatabaseConnectionString")?.Value);

            return new ShipViewModelDbContext(optionsBuilder.Options, settingsProvider);
        }
    }
}
