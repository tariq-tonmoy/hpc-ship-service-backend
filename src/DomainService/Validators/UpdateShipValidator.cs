using FluentValidation;
using ShipService.Domain.ShipEvents.EventMessages;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using System;

namespace ShipService.Domain.DomainService.Validators
{
    public class UpdateShipValidator<TAggregateRoot> : ShipValidator
        where TAggregateRoot : AggregateRoot
    {
        private readonly TAggregateRoot aggregateRoot;


        public UpdateShipValidator(TAggregateRoot aggregateRoot, UserContext userContext, string actionName, string serviceName)
            : base(userContext, actionName, serviceName)
        {
            this.aggregateRoot = aggregateRoot;

            this.When(dto => dto.ShipId != Guid.Empty, () =>
            {
                this.RuleFor(x => x.ShipId)
                    .Must(shipId => this.aggregateRoot.IsMarkedToDelete == false)
                    .WithState(dto => new BusinessRuleViolationEventMessage(
                        EventMessageType.FAILED,
                        BusinessRuleValidationCodes.ShipDoesNotExists,
                        userContext.UserId,
                        Guid.Empty,
                        "ShipId doesnot exist",
                        nameof(dto.ShipId),
                        dto.ShipId,
                        actionName,
                        serviceName));
            });
        }
    }
}
