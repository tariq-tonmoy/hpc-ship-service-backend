using ShipService.Infrastructure.Core.UserContextProvider;
using System;

namespace ShipService.Infrastructure.Core
{
    public interface IMessage
    {
        Guid CorrelationId { get; set; }

        UserContext UserContext { get; }

        void SetUserContext(UserContext userContext);
    }
}
