using Microsoft.EntityFrameworkCore;
using ShipService.External.NotificationHost.Models;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.NotificationHost.Repository
{
    public class NotificationDbContext : DbContext, IReadSideUnitOfWork<NotificationClient>
    {
        private readonly IDbConnectionSettingsProvider connectionSettingsProvider;

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options, IDbConnectionSettingsProvider connectionSettingsProvider)
            : base(options)
        {
            this.connectionSettingsProvider = connectionSettingsProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbConnectionString = this.connectionSettingsProvider.GetDbConnectionString(this);
            optionsBuilder.UseSqlite(dbConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NotificationClientConfiguration());


            modelBuilder.Entity<NotificationClient>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Version = 1,
                RolesAllowedToRead = string.Empty,
                IsMarkedToDelete = false,
                CorrelationId = Guid.NewGuid(),
                ClientId = "abcd"
            });

        }
    }
}
