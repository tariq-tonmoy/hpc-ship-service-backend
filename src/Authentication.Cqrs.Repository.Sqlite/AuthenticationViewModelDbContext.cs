using ShipService.External.AuthViewModel;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;

namespace ShipService.External.Infrastructure.Authentication.Cqrs.Repository.Sqlite
{
    public class AuthenticationViewModelDbContext : DbContext, IReadSideUnitOfWork<AuthenticationViewModel>
    {
        private readonly IDbConnectionSettingsProvider connectionSettingsProvider;

        public AuthenticationViewModelDbContext(DbContextOptions<AuthenticationViewModelDbContext> options, IDbConnectionSettingsProvider connectionSettingsProvider)
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
            modelBuilder.ApplyConfiguration(new AuthenticationViewModelConfiguration());

            modelBuilder.Entity<AuthenticationViewModel>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Password = "Abc123",
                Username = "test_admin1@yopmail.com",
                Version = 1,
                RolesAllowedToRead = string.Empty,
                Role = "Admin",
                IsMarkedToDelete = false,
            });

            modelBuilder.Entity<AuthenticationViewModel>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Password = "Abc123",
                Username = "test_admin2@yopmail.com",
                Version = 1,
                RolesAllowedToRead = string.Empty,
                Role = "Admin",
                IsMarkedToDelete = false,
            });

            modelBuilder.Entity<AuthenticationViewModel>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Password = "Abc123",
                Username = "test_user1@yopmail.com",
                Version = 1,
                RolesAllowedToRead = string.Empty,
                Role = "User",
                IsMarkedToDelete = false,
            });

            modelBuilder.Entity<AuthenticationViewModel>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Password = "Abc123",
                Username = "test_user2@yopmail.com",
                Version = 1,
                RolesAllowedToRead = string.Empty,
                Role = "User",
                IsMarkedToDelete = false,
            });
            modelBuilder.Entity<AuthenticationViewModel>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Password = "Abc123",
                Username = "test_anon1@yopmail.com",
                Version = 1,
                RolesAllowedToRead = string.Empty,
                Role = "Anonymous",
                IsMarkedToDelete = false,
            });

            modelBuilder.Entity<AuthenticationViewModel>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTime.UtcNow,
                Password = "Abc123",
                Username = "test_anon2@yopmail.com",
                Version = 1,
                RolesAllowedToRead = string.Empty,
                Role = "Anonymous",
                IsMarkedToDelete = false,
            });

        }
    }
}
