using FluentValidation;
using ShipService.Domain.ShipEvents.EventMessages;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;

namespace ShipService.Domain.DomainService.Validators
{
    public class DeactivateShipValidator<TAggregateRoot> : AbstractValidator<DeactivateShipDto>
        where TAggregateRoot : AggregateRoot
    {
        private readonly TAggregateRoot aggregateRoot;

        public DeactivateShipValidator(TAggregateRoot aggregateRoot, UserContext userContext, string actionName, string serviceName)
        {
            this.aggregateRoot = aggregateRoot;

            this.RuleFor(x => x.ShipId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithState(dto => new BusinessRuleViolationEventMessage(
                    EventMessageType.FAILED,
                    BusinessRuleValidationCodes.PropertyValueMissing,
                    userContext.UserId,
                    Guid.Empty,
                    "ShipId missing",
                    nameof(dto.ShipId),
                    Guid.Empty,
                    actionName,
                    serviceName))
                .NotEqual(Guid.Empty)
                .WithState(dto => new BusinessRuleViolationEventMessage(
                    EventMessageType.FAILED,
                    BusinessRuleValidationCodes.PropertyValueMissing,
                    userContext.UserId,
                    Guid.Empty,
                    "ShipId missing",
                    nameof(dto.ShipId),
                    Guid.Empty,
                    actionName,
                    serviceName))
                .Must(shipId => this.aggregateRoot.IsMarkedToDelete == false)
                .WithState(dto => new BusinessRuleViolationEventMessage(
                    EventMessageType.FAILED,
                    BusinessRuleValidationCodes.ShipIsAlreadyDeactivated,
                    userContext.UserId,
                    Guid.Empty,
                    "Ship Already Deactivated",
                    nameof(dto.ShipId),
                    Guid.Empty,
                    actionName,
                    serviceName));
        }
    }
}
