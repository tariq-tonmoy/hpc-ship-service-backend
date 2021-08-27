using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Domain.ShipEvents.EventMessages
{
    public class SuccessEventMessage : EventMessage
    {
        public SuccessEventMessage(EventMessageType eventMessageCode, string code)
            : base(eventMessageCode, code, new object[] { })
        {
        }
    }
}
