using FluentValidation.Results;
using ShipService.Domain.DomainService;
using ShipService.Domain.DomainService.Validators;
using ShipService.Domain.ShipAggregateRoot.Domains;
using ShipService.Domain.ShipEvents;
using ShipService.Domain.ShipEvents.EventMessages;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.Infrastructure.Utilities.Abstractions;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipService.Domain.ShipAggregateRoot
{
    public class ShipAggregateRoot : AggregateRoot
    {
        private List<ShipDimension> shipDimensions;
        public string ShipName { get; protected set; }

        public string Code { get; protected set; }

        public IReadOnlyCollection<ShipDimension> ShipDimensions => shipDimensions;

        private void AddValidationEvents(ValidationResult validationResult, Guid entityId, UserContext userContext, Guid correlationId)
        {
            var errors = validationResult.Errors.Select(e => e.CustomState as EventMessage).ToList();
            if (errors != null && errors.Any())
            {
                this.AddEvent(new ShipBusinessRuleViolatedEvent(entityId, errors, userContext, correlationId));
                return;
            }
        }

        private void RemoveMissingDimensions(ShipDto shipDto)
        {
            var dimensionDtoIds = shipDto.Dimensions.Select(x => x.DimensionId);
            var dimensionCount = this.shipDimensions.Count;
            List<ShipDimension> dimensionsToRemove = new List<ShipDimension>();
            if (dimensionCount > 0)
            {
                for (int i = 0; i < dimensionCount; i++)
                {
                    if (dimensionDtoIds.Contains(this.shipDimensions[i].DimensionId) == false)
                    {
                        dimensionsToRemove.Add(this.shipDimensions[i]);
                    }
                }
            }

            if (dimensionsToRemove != null && dimensionsToRemove.Any())
            {
                foreach (var dimensionToRemove in dimensionsToRemove)
                {
                    this.shipDimensions.Remove(dimensionToRemove);
                }
            }
        }

        private void UpdateDimensions(ShipDto shipDto)
        {
            if (this.shipDimensions == null)
            {
                this.shipDimensions = new List<ShipDimension>();
            }


            foreach (var dimensionDto in shipDto.Dimensions)
            {
                var dimension = this.shipDimensions.FirstOrDefault(x => x.DimensionId == dimensionDto.DimensionId);

                if (dimension == null)
                {
                    this.shipDimensions.Add(ShipDimension.AddDimension(dimensionDto));
                }
                else
                {
                    dimension = ShipDimension.UpdateDimension(dimensionDto, dimension);
                }
            }
        }

        private void UpdateShipData(ShipDto shipDto)
        {
            this.Id = shipDto.ShipId;
            this.Code = shipDto.Code;
            this.IsMarkedToDelete = false;
            this.ShipName = shipDto.ShipName;

            this.UpdateDimensions(shipDto);
            this.RemoveMissingDimensions(shipDto);
        }

        private ShipEventDto GenerateShipEventDto()
        {
            return new ShipEventDto()
            {
                Code = this.Code,
                CreatedBy = this.CreatedBy,
                CreatedDate = this.CreatedDate,
                Dimensions = this.shipDimensions.Select(x => new DimensionDto()
                {
                    DimensionId = x.DimensionId,
                    Height = x.Height,
                    Unit = x.Unit,
                    Width = x.Width,
                }),
                IsMarkedToDelete = this.IsMarkedToDelete,
                LastUpdatedBy = this.LastUpdatedBy,
                LastUpdatedDate = this.LastUpdatedDate,
                ShipId = this.Id,
                ShipName = this.ShipName,
            };
        }

        public void AddShip(
            ShipDto ship,
            UserContext userContext,
            Guid correlationId,
            IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository,
            IDateTimeProvider dateTimeProvider)
        {
            var validationResult = new CreateShipValidator<ShipAggregateRoot>(aggregateRootRepository, userContext, nameof(this.AddShip), nameof(ShipAggregateRoot)).Validate(ship);
            this.AddValidationEvents(validationResult, ship.ShipId, userContext, correlationId);
            if (this.DomainEvents != null && this.DomainEvents.Any(x => x is BusinessRuleViolatedEvent))
            {
                return;
            }

            this.SetDefaultValues(userContext, dateTimeProvider);
            this.UpdateShipData(ship);
            SuccessEventMessage successEventMessage = new SuccessEventMessage(EventMessageType.SUCCESS, BusinessRuleValidationCodes.Success);

            ShipCreatedEvent @event = new ShipCreatedEvent(
                this.GenerateShipEventDto(),
                ship,
                successEventMessage,
                userContext,
                correlationId);
            this.AddEvent(@event);
            @event.EventDto.Version = this.Version;
        }

        public void UpdateShip(
            ShipDto ship,
            UserContext userContext,
            Guid correlationId,
            IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository,
            IDateTimeProvider dateTimeProvider)
        {
            var validationResult = new UpdateShipValidator<ShipAggregateRoot>(this, userContext, nameof(this.UpdateShip), nameof(ShipAggregateRoot)).Validate(ship);
            this.AddValidationEvents(validationResult, this.Id, userContext, correlationId);
            if (this.DomainEvents != null && this.DomainEvents.Any(x => x is BusinessRuleViolatedEvent))
            {
                return;
            }

            this.SetDefaultValues(userContext, dateTimeProvider);
            this.UpdateShipData(ship);
            SuccessEventMessage successEventMessage = new SuccessEventMessage(EventMessageType.SUCCESS, BusinessRuleValidationCodes.Success);

            ShipUpdatedEvent @event = new ShipUpdatedEvent(
                this.GenerateShipEventDto(),
                ship,
                successEventMessage,
                userContext,
                correlationId);
            this.AddEvent(@event);
            @event.EventDto.Version = this.Version;
        }

        public void DeactivateShip(
            DeactivateShipDto ship,
            UserContext userContext,
            Guid correlationId,
            IAggregateRootRepository<ShipAggregateRoot> aggregateRootRepository,
            IDateTimeProvider dateTimeProvider)
        {
            var validationResult = new DeactivateShipValidator<ShipAggregateRoot>(this, userContext, nameof(this.UpdateShip), nameof(ShipAggregateRoot)).Validate(ship);
            this.AddValidationEvents(validationResult, this.Id, userContext, correlationId);
            if (this.DomainEvents != null && this.DomainEvents.Any(x => x is BusinessRuleViolatedEvent))
            {
                return;
            }

            this.SetDefaultValues(userContext, dateTimeProvider);
            this.IsMarkedToDelete = true;
            if (this.shipDimensions != null && this.shipDimensions.Any())
            {
                this.shipDimensions.Clear();
            }

            SuccessEventMessage successEventMessage = new SuccessEventMessage(EventMessageType.SUCCESS, BusinessRuleValidationCodes.Success);

            ShipDeactivatedEvent @event = new ShipDeactivatedEvent(
                this.GenerateShipEventDto(),
                ship,
                successEventMessage,
                userContext,
                correlationId);
            this.AddEvent(@event);
            @event.EventDto.Version = this.Version;
        }
    }
}
