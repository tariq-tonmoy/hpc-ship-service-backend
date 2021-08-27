using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;

namespace ShipService.Domain.ShipEvents
{
    public class ShipBusinessRuleViolatedEvent : BusinessRuleViolatedEvent
    {
        public ShipBusinessRuleViolatedEvent(Guid entityId, IEnumerable<EventMessage> eventMessages, UserContext userContext, Guid correlationId)
            : base(entityId, eventMessages, userContext, correlationId)
        {
            this.CorrelationId = correlationId;
            this.SetUserContext(userContext);
        }
    }
}
