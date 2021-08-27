using ShipService.Infrastructure.Cqrs.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using ShipService.Domain.ShipAggregateRoot;
using ShipService.Domain.ShipAggregateRoot.Domains;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    public class ShipAggregateRootDbContext : DbContext, IAggregateRootUnitOfWork<ShipAggregateRoot>
    {
        private readonly IDbConnectionSettingsProvider connectionSettingsProvider;

        public ShipAggregateRootDbContext(DbContextOptions<ShipAggregateRootDbContext> options, IDbConnectionSettingsProvider connectionSettingsProvider)
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
            modelBuilder.ApplyConfiguration(new ShipAggregateRootConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionConfiguration());

            Guid id = Guid.Parse("882637bc-050b-48d7-a802-88920c53036c");
            Guid dimensionId1 = Guid.Parse("5c07bacc-afa9-4931-8b5f-566cff2a05f0");
            Guid dimensionId2 = Guid.Parse("255f68a0-d11f-4a45-ba13-afcfc258e276");

            modelBuilder.Entity<ShipAggregateRoot>().HasData(
            new
            {
                Id = id,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Version = 1,
                IsMarkedToDelete = false,
                ShipName = "Ship 1",
                Code = "AAAA-1111-A1"
            });

            modelBuilder.Entity<ShipDimension>().HasData(
            new
            {
                DomainId = dimensionId1,
                DimensionId = dimensionId1,
                Height = (decimal)1.1,
                Width = (decimal)2.2,
                Unit = "Meters",
                ShipAggregateRootId = id,
            });

            modelBuilder.Entity<ShipDimension>().HasData(
            new
            {
                DomainId = dimensionId2,
                DimensionId = dimensionId2,
                Height = (decimal)121.1,
                Width = (decimal)221.2,
                Unit = "Feet",
                ShipAggregateRootId = id,
            });

        }
    }
}
