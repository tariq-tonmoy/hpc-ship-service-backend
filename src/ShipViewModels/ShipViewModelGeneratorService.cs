using ShipService.ReadSilde.ViewModels.Abstractions;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ViewModels
{
    public class ShipViewModelGeneratorService : IShipViewModelGeneratorService
    {
        private ShipViewModel AddDimensionViewModels(ShipViewModel viewModel, IEnumerable<DimensionDto> dimensions)
        {
            foreach (var dimension in dimensions)
            {
                viewModel.AddDimension(dimension);
            }

            return viewModel;
        }

        private ShipViewModel GetShipViewModel(ShipEventDto shipEventDto, IEnumerable<DimensionDto> dimensions, Guid id)
        {
            var viewModel = new ShipViewModel(
                        id,
                        shipEventDto.Version,
                        shipEventDto.CreatedBy,
                        shipEventDto.LastUpdatedBy,
                        shipEventDto.CreatedDate,
                        shipEventDto.LastUpdatedDate,
                        shipEventDto.IsMarkedToDelete,
                        shipEventDto.ShipId,
                        shipEventDto.ShipName,
                        shipEventDto.Code);

            return this.AddDimensionViewModels(viewModel, dimensions);
        }

        public ShipViewModel GetShipViewModel(ShipEventDto shipEventDto)
        {
            return this.GetShipViewModel(shipEventDto, shipEventDto.Dimensions, Guid.NewGuid());
        }

        public ShipViewModel GetShipViewModel(ShipViewModel existingViewModel, ShipEventDto shipEventDto)
        {
            return this.GetShipViewModel(shipEventDto, shipEventDto.Dimensions, existingViewModel.Id);
        }
    }
}
