using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Domain.ShipEvents.EventMessages
{
    public class BusinessRuleViolationEventMessage : EventMessage
    {
        public BusinessRuleViolationEventMessage(EventMessageType eventMessageCode, string code, Guid userId, Guid shipId, string message, string propertyName, object propertyValue, string actionName, string serviceName)
            : base(eventMessageCode, code, new object[] { userId, shipId, message, propertyName, propertyValue, actionName, serviceName })
        {
        }
    }
}
