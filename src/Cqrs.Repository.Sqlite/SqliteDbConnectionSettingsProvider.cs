using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ShipService.Infrastructure.Cqrs.Repository.Sqlite
{
    public class SqliteDbConnectionSettingsProvider : IDbConnectionSettingsProvider
    {
        private readonly IConfiguration configuration;

        public SqliteDbConnectionSettingsProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private void CreateDirectoryForSqliteDb(string dbConnectionString)
        {
            if (!string.IsNullOrWhiteSpace(dbConnectionString))
            {
                var directoryName = Path.GetDirectoryName(dbConnectionString);
                Directory.CreateDirectory(directoryName);
            }
        }

        private string ExtractFilePathFromConnectionString(string dbConnectionString)
        {
            string filePath = dbConnectionString.Replace("Data Source=", string.Empty);
            return filePath;
        }

        private string GetDbConnectionString(string connectionString)
        {
            var dbConnectionString = this.configuration.GetSection(connectionString)?.Value;
            if (!string.IsNullOrWhiteSpace(dbConnectionString))
            {
                var filePath = this.ExtractFilePathFromConnectionString(dbConnectionString);

                this.CreateDirectoryForSqliteDb(filePath);
            }
            return dbConnectionString;
        }

        public string GetDbConnectionString(IUnitOfWork unitOfWork)
        {
            return this.GetDbConnectionString(unitOfWork is IReadSideUnitOfWork<ViewModelBase> ? "ReadDatabaseConnectionString"
                : unitOfWork is IAggregateRootUnitOfWork<AggregateRoot> ? "StateDatabaseConnectionString" : string.Empty);
        }
    }
}
