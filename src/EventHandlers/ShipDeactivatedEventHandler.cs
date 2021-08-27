using ShipService.Domain.ShipEvents;
using ShipService.Infrastructure.Core.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.ReadSilde.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.EventHandlers
{
    public class ShipDeactivatedEventHandler : IAsyncEventHandler<ShipDeactivatedEvent>
    {
        private readonly IReadRepository<ShipViewModel> readRepository;

        public ShipDeactivatedEventHandler(IReadRepository<ShipViewModel> readRepository)
        {
            this.readRepository = readRepository;
        }

        public Task HandleAsync(ShipDeactivatedEvent @event)
        {
            var existinViewModels = this.readRepository.GetByFilter(x => x.ShipId == @event.EventDto.ShipId).ToList();
            if (existinViewModels != null && existinViewModels.Any())
            {
                existinViewModels.ForEach(async x => await this.readRepository.DeleteAsync(x));
            }

            return Task.CompletedTask;
        }
    }
}
