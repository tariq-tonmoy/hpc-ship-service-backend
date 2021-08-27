using ShipService.Domain.ShipEvents;
using ShipService.Infrastructure.Core.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.ReadSilde.ViewModels;
using ShipService.ReadSilde.ViewModels.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.EventHandlers
{
    public class ShipUpdatedEventHandler : IAsyncEventHandler<ShipUpdatedEvent>
    {
        private readonly IReadRepository<ShipViewModel> readRepository;
        private readonly IShipViewModelGeneratorService viewModelGeneratorService;

        public ShipUpdatedEventHandler(IReadRepository<ShipViewModel> readRepository, IShipViewModelGeneratorService viewModelGeneratorService)
        {
            this.readRepository = readRepository;
            this.viewModelGeneratorService = viewModelGeneratorService;
        }

        public async Task HandleAsync(ShipUpdatedEvent @event)
        {
            if (@event.EventDto != null && @event.EventDto.Dimensions != null && @event.EventDto.Dimensions.Any())
            {
                var existinViewModels = this.readRepository.GetByFilter(x => x.ShipId == @event.EventDto.ShipId).ToList();

                foreach (var existinViewModel in existinViewModels)
                {
                    await this.readRepository.DeleteAsync(existinViewModel);
                    var viewModel = this.viewModelGeneratorService.GetShipViewModel(existinViewModel, @event.EventDto);
                    await this.readRepository.SaveAsync(viewModel);
                }
            }
        }
    }
}
