using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ViewModels.Abstractions
{
    public interface IShipViewModelGeneratorService
    {
        ShipViewModel GetShipViewModel(ShipEventDto shipEventDto);

        ShipViewModel GetShipViewModel(ShipViewModel existingViewModel, ShipEventDto shipEventDto);
    }
}
