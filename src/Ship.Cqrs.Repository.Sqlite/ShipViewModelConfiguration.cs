using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ShipService.ReadSilde.ViewModels;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    internal class ShipViewModelConfiguration : IEntityTypeConfiguration<ShipViewModel>
    {
        public void Configure(EntityTypeBuilder<ShipViewModel> builder)
        {
            builder.ToTable($"{typeof(ShipViewModel).Name}s");
            builder.HasKey(viewModel => viewModel.Id);

            builder
            .Property<Guid>(nameof(ShipViewModel.Id))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.Id))
            .IsRequired(true);

            builder
            .Property<string>(nameof(ShipViewModel.Code))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.Code))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(ShipViewModel.CreatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.CreatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(ShipViewModel.CreatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.CreatedDate))
            .IsRequired(true);

            builder
            .Property<bool>(nameof(ShipViewModel.IsMarkedToDelete))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.IsMarkedToDelete))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(ShipViewModel.LastUpdatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.LastUpdatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(ShipViewModel.LastUpdatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.LastUpdatedDate))
            .IsRequired(true);

            builder
            .Property<string>(nameof(ShipViewModel.RolesAllowedToRead))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.RolesAllowedToRead))
            .IsRequired(false);

            builder
            .Property<Guid>(nameof(ShipViewModel.ShipId))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.ShipId))
            .IsRequired(true);

            builder
            .Property<string>(nameof(ShipViewModel.ShipName))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.ShipName))
            .IsRequired(true);

            builder
            .Property<int>(nameof(ShipViewModel.Version))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipViewModel.Version))
            .IsRequired(true);

            var navigation = builder.Metadata.FindNavigation(nameof(ShipViewModel.DimensionViewModels));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);


            builder.HasMany(ship => ship.DimensionViewModels)
                   .WithOne(dimension => dimension.ShipViewModel)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
