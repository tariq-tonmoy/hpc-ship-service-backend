using ShipService.Domain.ShipEvents;
using ShipService.Infrastructure.Core.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.ReadSilde.ViewModels;
using ShipService.ReadSilde.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.EventHandlers
{
    public class ShipCreatedEventHandler : IAsyncEventHandler<ShipCreatedEvent>
    {
        private readonly IReadRepository<ShipViewModel> readRepository;
        private readonly IShipViewModelGeneratorService viewModelGeneratorService;

        public ShipCreatedEventHandler(IReadRepository<ShipViewModel> readRepository, IShipViewModelGeneratorService viewModelGeneratorService)
        {
            this.readRepository = readRepository;
            this.viewModelGeneratorService = viewModelGeneratorService;
        }

        public async Task HandleAsync(ShipCreatedEvent @event)
        {
            if (@event.EventDto != null && @event.EventDto.Dimensions != null && @event.EventDto.Dimensions.Any())
            {
                var viewModel = this.viewModelGeneratorService.GetShipViewModel(@event.EventDto);
                await this.readRepository.SaveAsync(viewModel);
            }
        }
    }
}
