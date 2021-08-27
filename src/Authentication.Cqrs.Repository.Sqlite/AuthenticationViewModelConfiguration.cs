using ShipService.External.AuthViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ShipService.External.Infrastructure.Authentication.Cqrs.Repository.Sqlite
{
    internal class AuthenticationViewModelConfiguration : IEntityTypeConfiguration<AuthenticationViewModel>
    {
        public void Configure(EntityTypeBuilder<AuthenticationViewModel> builder)
        {
            builder.ToTable($"{typeof(AuthenticationViewModel).Name}s");
            builder.HasKey(viewModel => viewModel.Id);

            builder
            .Property<Guid>(nameof(AuthenticationViewModel.Id))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.Id))
            .IsRequired(true);

            builder
            .Property<int>(nameof(AuthenticationViewModel.Version))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.Version))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(AuthenticationViewModel.CreatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.CreatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(AuthenticationViewModel.CreatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.CreatedDate))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(AuthenticationViewModel.LastUpdatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.LastUpdatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(AuthenticationViewModel.LastUpdatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.LastUpdatedDate))
            .IsRequired(true);

            builder
            .Property<string>(nameof(AuthenticationViewModel.Password))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.Password))
            .IsRequired(true);

            builder
            .Property<string>(nameof(AuthenticationViewModel.RolesAllowedToRead))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.RolesAllowedToRead))
            .IsRequired(false);

            builder
           .Property<string>(nameof(AuthenticationViewModel.Role))
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName(nameof(AuthenticationViewModel.Role))
           .IsRequired(true);

            builder
            .Property<string>(nameof(AuthenticationViewModel.Username))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(AuthenticationViewModel.Username))
            .IsRequired(true);

            builder
           .Property<bool>(nameof(AuthenticationViewModel.IsMarkedToDelete))
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName(nameof(AuthenticationViewModel.IsMarkedToDelete))
           .IsRequired(true);

        }
    }
}
