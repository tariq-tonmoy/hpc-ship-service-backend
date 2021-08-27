using Microsoft.Extensions.Logging;
using ShipService.Application.Commands;
using ShipService.Domain.ShipAggregateRoot;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.Abstractions;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Utilities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Application.CommandHandlers
{
    public class UpdateShipsCommandHandler : IAsyncCommandHandler<UpdateShipsCommand>
    {
        private readonly ILogger<UpdateShipsCommandHandler> logger;
        private readonly IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IPublishEventsAsBulkService eventPublishService;

        public UpdateShipsCommandHandler(
            ILogger<UpdateShipsCommandHandler> logger,
            IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository,
            IDateTimeProvider dateTimeProvider,
            IPublishEventsAsBulkService eventPublishService)
        {
            this.logger = logger;
            this.aggregateRootRepository = aggregateRootRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.eventPublishService = eventPublishService;
        }

        public async Task<CommandRespose> HandleAsync(UpdateShipsCommand command)
        {
            if (command.ShipsToUpdate != null && command.ShipsToUpdate.Any())
            {
                foreach (var ship in command.ShipsToUpdate)
                {
                    var aggregateRoot = await this.aggregateRootRepository.GetByIdAsync(ship.ShipId, x => x.ShipDimensions);
                    if (aggregateRoot != null)
                    {
                        aggregateRoot.UpdateShip(ship, command.UserContext, command.CorrelationId, this.aggregateRootRepository, this.dateTimeProvider);
                        await this.aggregateRootRepository.UpdateAsync(aggregateRoot);
                        await this.eventPublishService.PublishBulkEvents(aggregateRoot.DomainEvents);
                    }
                }
            }

            return new CommandRespose();
        }
    }
}
