using FluentValidation;
using ShipService.Domain.ShipEvents.EventMessages;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipService.Domain.DomainService.Validators
{
    public class CreateShipValidator<TAggregateRoot> : ShipValidator
        where TAggregateRoot : AggregateRoot
    {
        private readonly IAggregateRootRepository<TAggregateRoot> aggregateRootRepository;

        public CreateShipValidator(IAggregateRootRepository<TAggregateRoot> aggregateRootRepository, UserContext userContext, string actionName, string serviceName)
            : base(userContext, actionName, serviceName)
        {
            this.aggregateRootRepository = aggregateRootRepository;

            this.When(dto => dto.ShipId != Guid.Empty, () =>
            {
                this.RuleFor(x => x.ShipId)
                    .MustAsync(this.IsNewAggregateRoot)
                    .WithState(dto => new BusinessRuleViolationEventMessage(
                        EventMessageType.FAILED,
                        BusinessRuleValidationCodes.ShipAlreadyCreated,
                        userContext.UserId,
                        Guid.Empty,
                        "ShipId already exists",
                        nameof(dto.ShipId),
                        dto.ShipId,
                        actionName,
                        serviceName));
            });
        }

        private async Task<bool> IsNewAggregateRoot(Guid shipId, CancellationToken token)
        {
            return (await this.aggregateRootRepository.ExistsAsync(shipId)) == false;
        }
    }
}
