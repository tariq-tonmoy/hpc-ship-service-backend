using ShipService.Infrastructure.Cqrs.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using ShipService.ReadSilde.ViewModels;
using System;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    public class ShipViewModelDbContext : DbContext, IReadSideUnitOfWork<ShipViewModel>
    {
        private readonly IDbConnectionSettingsProvider connectionSettingsProvider;

        public ShipViewModelDbContext(DbContextOptions<ShipViewModelDbContext> options, IDbConnectionSettingsProvider connectionSettingsProvider)
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
            modelBuilder.ApplyConfiguration(new ShipViewModelConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionViewModelConfiguration());

            var id1 = Guid.Parse("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37");
            var id2 = Guid.Parse("b308da0e-c000-4a35-8244-793f5699d7e7");
            var id3 = Guid.Parse("ec4622fd-a610-4775-b3f0-ce2488f203f2");
            var id4 = Guid.Parse("851b7c67-462e-46d4-8ecf-8c75e53a661d");

            var id5 = Guid.Parse("ec4622fd-a610-4775-b3f0-ce2488f203f3");
            var id6 = Guid.Parse("851b7c67-462e-46d4-8ecf-8c75e53a661e");

            var shipId = Guid.Parse("851b7c67-462e-46d4-8ecf-8c75e53a6601");
            var DimensionId1 = Guid.Parse("851b7c67-462e-46d4-8ecf-8c75e53a6602");
            var DimensionId2 = Guid.Parse("851b7c67-462e-46d4-8ecf-8c75e53a6603");

            modelBuilder.Entity<ShipViewModel>().HasData(
            new
            {
                Id = id1,
                ShipId = shipId,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Version = 1,
                IsMarkedToDelete = false,
                ShipName = "Ship 1",
                Code = "AAAA-1111-A1",
            });

            modelBuilder.Entity<ShipViewModel>().HasData(
            new
            {
                Id = id2,
                ShipId = shipId,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Version = 1,
                IsMarkedToDelete = false,
                ShipName = "Ship 2",
                Code = "BBBB-2222-B2",
            });

            modelBuilder.Entity<DimensionViewModel>().HasData(
            new
            {
                ViewModelId = id3,
                DimensionId = DimensionId1,
                Height = (decimal)1.1,
                Width = (decimal)2.2,
                Unit = "Meters",
                ShipViewModelId = id1,
            });

           modelBuilder.Entity<DimensionViewModel>().HasData(
           new
           {
               ViewModelId = id4,
               DimensionId = DimensionId2,
               Height = (decimal)10.1,
               Width = (decimal)2.20,
               Unit = "Feet",
               ShipViewModelId = id1,
           });

            modelBuilder.Entity<DimensionViewModel>().HasData(
            new
            {
                ViewModelId = id5,
                DimensionId = DimensionId1,
                Height = (decimal)1.1,
                Width = (decimal)2.2,
                Unit = "Meters",
                ShipViewModelId = id2,
            });

            modelBuilder.Entity<DimensionViewModel>().HasData(
            new
            {
                ViewModelId = id6,
                DimensionId = DimensionId2,
                Height = (decimal)10.1,
                Width = (decimal)2.20,
                Unit = "Feet",
                ShipViewModelId = id2,
            });

        }
    }
}
