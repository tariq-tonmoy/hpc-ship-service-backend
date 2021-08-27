using Newtonsoft.Json;
using ShipService.Infrastructure.Core.UserContextProvider;
using System;

namespace ShipService.Infrastructure.Core
{
    public class Command : IMessage
    {
        public Guid CorrelationId { get; set; }

        public UserContext UserContext { get; private set; }

        public void SetUserContext(UserContext userContext)
        {
            this.UserContext = userContext;
        }
    }
}
