using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipService.ReadSilde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite
{
    public class DimensionViewModelConfiguration : IEntityTypeConfiguration<DimensionViewModel>
    {
        public void Configure(EntityTypeBuilder<DimensionViewModel> builder)
        {
            builder.ToTable($"{typeof(DimensionViewModel).Name}s");
            builder.HasKey(viewModel => viewModel.ViewModelId);

            builder
            .Property<Guid>(nameof(DimensionViewModel.ViewModelId))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .ValueGeneratedOnAdd()
            .HasColumnName(nameof(DimensionViewModel.ViewModelId))
            .IsRequired(true);

            builder
            .Property<Guid>(nameof(DimensionViewModel.DimensionId))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(DimensionViewModel.DimensionId))
            .IsRequired(true);

            builder
            .Property<decimal>(nameof(DimensionViewModel.Height))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(DimensionViewModel.Height))
            .IsRequired(true);

            builder
            .Property<decimal>(nameof(DimensionViewModel.Width))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(DimensionViewModel.Width))
            .IsRequired(true);

            builder
            .Property<string>(nameof(DimensionViewModel.Unit))
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName(nameof(DimensionViewModel.Unit))
            .IsRequired(true);
        }
    }
}
