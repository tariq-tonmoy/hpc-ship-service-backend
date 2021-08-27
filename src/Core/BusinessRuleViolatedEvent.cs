using ShipService.Infrastructure.Core.UserContextProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Core
{
    public class BusinessRuleViolatedEvent : DomainEvent
    {
        public BusinessRuleViolatedEvent(Guid entityId, IEnumerable<EventMessage> eventMessages, UserContext userContext, Guid correlationId)
        {
            this.EntityId = entityId;
            this.EventMessages = eventMessages;
            this.CorrelationId = correlationId;
            this.SetUserContext(userContext);
        }

        public Guid EntityId { get; }

        public IEnumerable<EventMessage> EventMessages { get; }
    }
}
