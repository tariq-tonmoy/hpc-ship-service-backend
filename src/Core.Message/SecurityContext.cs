using System;

namespace ShipService.Infrastructure.Core.UserContextProvider
{
    public class SecurityContext
    {
        public SecurityContext(UserContext userContext)
        {
            this.UserContext = userContext;
        }


        public UserContext UserContext { get; internal set; }
    }
}
