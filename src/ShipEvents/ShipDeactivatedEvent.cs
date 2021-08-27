using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;

namespace ShipService.Domain.ShipEvents
{
    public class ShipDeactivatedEvent : DomainEvent
    {
        public ShipDeactivatedEvent(ShipEventDto eventDto, DeactivateShipDto deactivateShipDto, EventMessage eventMessage, UserContext userContext, Guid correlationId)
        {
            this.EventDto = eventDto;
            this.DeactivateShipDto = deactivateShipDto;
            this.EventMessage = eventMessage;
            this.CorrelationId = correlationId;
            this.SetUserContext(userContext);
        }

        public ShipEventDto EventDto { get; }

        public DeactivateShipDto DeactivateShipDto { get; }

        public EventMessage EventMessage { get; }
    }
}
