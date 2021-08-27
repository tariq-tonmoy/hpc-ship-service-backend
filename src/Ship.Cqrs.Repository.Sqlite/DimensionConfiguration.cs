using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ShipService.Domain.ShipAggregateRoot;
using ShipService.Domain.ShipAggregateRoot.Domains;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    internal class DimensionConfiguration : IEntityTypeConfiguration<ShipDimension>
    {
        public void Configure(EntityTypeBuilder<ShipDimension> builder)
        {
            builder.ToTable($"{typeof(ShipDimension).Name}s");
            builder.HasKey(dimension => dimension.DomainId);

            builder
            .Property<Guid>(nameof(ShipDimension.DomainId))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .ValueGeneratedOnAdd()
            .HasColumnName(nameof(ShipDimension.DomainId))
            .IsRequired(true);

            builder
           .Property<Guid>(nameof(ShipDimension.DimensionId))
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName(nameof(ShipDimension.DimensionId))
           .IsRequired(true);

            builder
            .Property<decimal>(nameof(ShipDimension.Height))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipDimension.Height))
            .IsRequired(true);

            builder
            .Property<decimal>(nameof(ShipDimension.Width))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipDimension.Width))
            .IsRequired(true);

            builder
            .Property<string>(nameof(ShipDimension.Unit))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(ShipDimension.Unit))
            .IsRequired(true);
        }
    }
}
