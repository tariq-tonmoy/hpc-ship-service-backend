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
using ShipService.External.NotificationHost.Repository;

namespace ShipService.External.NotificationHost.Repository
{
    public class NotificationClientContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
    {
        public NotificationDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NotificationHost"))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{args[0]}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NotificationDbContext>();
            SqliteDbConnectionSettingsProvider settingsProvider = new SqliteDbConnectionSettingsProvider(config);

            optionsBuilder.UseSqlite(config.GetSection("ReadDatabaseConnectionString")?.Value);

            return new NotificationDbContext(optionsBuilder.Options, settingsProvider);
        }
    }
}
