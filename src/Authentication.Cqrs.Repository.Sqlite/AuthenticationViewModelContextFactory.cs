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

namespace ShipService.External.Infrastructure.Authentication.Cqrs.Repository.Sqlite
{
    public class AuthenticationViewModelContextFactory : IDesignTimeDbContextFactory<AuthenticationViewModelDbContext>
    {
        public AuthenticationViewModelDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AuthenticationQueryHost"))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{args[0]}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AuthenticationViewModelDbContext>();
            SqliteDbConnectionSettingsProvider settingsProvider = new SqliteDbConnectionSettingsProvider(config);

            optionsBuilder.UseSqlite(config.GetSection("ReadDatabaseConnectionString")?.Value);

            return new AuthenticationViewModelDbContext(optionsBuilder.Options, settingsProvider);
        }
    }
}
