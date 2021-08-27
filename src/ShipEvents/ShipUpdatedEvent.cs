using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;

namespace ShipService.Domain.ShipEvents
{
    public class ShipUpdatedEvent : DomainEvent
    {
        public ShipUpdatedEvent(ShipEventDto eventDto, ShipDto shipDto, EventMessage eventMessage, UserContext userContext, Guid correlationId)
        {
            this.EventDto = eventDto;
            this.ShipDto = shipDto;
            this.EventMessage = eventMessage;
            this.CorrelationId = correlationId;
            this.SetUserContext(userContext);
        }

        public ShipEventDto EventDto { get; }

        public ShipDto ShipDto { get; }

        public EventMessage EventMessage { get; }
    }
}
