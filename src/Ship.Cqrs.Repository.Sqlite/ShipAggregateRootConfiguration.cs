using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ShipService.Domain.ShipAggregateRoot;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    internal class ShipAggregateRootConfiguration : IEntityTypeConfiguration<ShipAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<ShipAggregateRoot> builder)
        {
            builder.ToTable($"{typeof(ShipAggregateRoot).Name}s");
            builder.HasKey(aggregateRoot => aggregateRoot.Id);
            builder.Ignore(b => b.DomainEvents);

            builder
            .Property<Guid>(nameof(ShipAggregateRoot.Id))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.Id))
            .IsRequired(true);

            builder
            .Property<int>(nameof(ShipAggregateRoot.Version))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.Version))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(ShipAggregateRoot.CreatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.CreatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(ShipAggregateRoot.CreatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.CreatedDate))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(ShipAggregateRoot.LastUpdatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.LastUpdatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(ShipAggregateRoot.LastUpdatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.LastUpdatedDate))
            .IsRequired(true);

            builder
            .Property<string>(nameof(ShipAggregateRoot.ShipName))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipAggregateRoot.ShipName))
            .IsRequired(true);

            builder
           .Property<bool>(nameof(ShipAggregateRoot.IsMarkedToDelete))
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName(nameof(ShipAggregateRoot.IsMarkedToDelete))
           .IsRequired(true);

            builder
           .Property<string>(nameof(ShipAggregateRoot.Code))
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName(nameof(ShipAggregateRoot.Code))
           .IsRequired(true);

            var navigation = builder.Metadata.FindNavigation(nameof(ShipAggregateRoot.ShipDimensions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);


            builder.HasMany(ship => ship.ShipDimensions)
                   .WithOne(dimension => dimension.ShipAggregateRoot)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
