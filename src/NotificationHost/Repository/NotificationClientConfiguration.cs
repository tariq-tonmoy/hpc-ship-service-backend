using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipService.External.NotificationHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.NotificationHost.Repository
{
    public class NotificationClientConfiguration : IEntityTypeConfiguration<NotificationClient>
    {
        public void Configure(EntityTypeBuilder<NotificationClient> builder)
        {
            builder.ToTable($"{typeof(NotificationClient).Name}s");
            builder.HasKey(viewModel => viewModel.Id);

            builder
            .Property<Guid>(nameof(NotificationClient.Id))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .ValueGeneratedOnAdd()
            .HasColumnName(nameof(NotificationClient.Id))
            .IsRequired(true);

            builder
            .Property<int>(nameof(NotificationClient.Version))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.Version))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(NotificationClient.CreatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.CreatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(NotificationClient.CreatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.CreatedDate))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(NotificationClient.LastUpdatedBy))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.LastUpdatedBy))
            .IsRequired(true);

            builder
            .Property<DateTime>(nameof(NotificationClient.LastUpdatedDate))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.LastUpdatedDate))
            .IsRequired(true);

            builder
            .Property<string>(nameof(NotificationClient.RolesAllowedToRead))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.RolesAllowedToRead))
            .IsRequired(false);

            builder
           .Property<Guid>(nameof(NotificationClient.CorrelationId))
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName(nameof(NotificationClient.CorrelationId))
           .IsRequired(true);

            builder
            .Property<string>(nameof(NotificationClient.ClientId))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.ClientId))
            .IsRequired(true);

            builder
            .Property<bool>(nameof(NotificationClient.IsMarkedToDelete))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(NotificationClient.IsMarkedToDelete))
            .IsRequired(true);
        }
    }
}
