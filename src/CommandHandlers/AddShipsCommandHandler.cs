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
    public class AddShipsCommandHandler : IAsyncCommandHandler<AddShipsCommand>
    {
        private readonly ILogger<AddShipsCommandHandler> logger;
        private readonly IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IPublishEventsAsBulkService eventPublishService;

        public AddShipsCommandHandler(
            ILogger<AddShipsCommandHandler> logger,
            IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository,
            IDateTimeProvider dateTimeProvider,
            IPublishEventsAsBulkService eventPublishService)
        {
            this.logger = logger;
            this.aggregateRootRepository = aggregateRootRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.eventPublishService = eventPublishService;
        }

        public async Task<CommandRespose> HandleAsync(AddShipsCommand command)
        {
            if (command.ShipsToAdd != null && command.ShipsToAdd.Any())
            {
                foreach (var ship in command.ShipsToAdd)
                {
                    var aggregateRoot = new ShipAggregateRoot();
                    aggregateRoot.AddShip(ship, command.UserContext, command.CorrelationId, this.aggregateRootRepository, this.dateTimeProvider);
                    await this.aggregateRootRepository.SaveAsync(aggregateRoot);
                    await this.eventPublishService.PublishBulkEvents(aggregateRoot.DomainEvents);
                }
            }

            return new CommandRespose();
        }
    }
}
