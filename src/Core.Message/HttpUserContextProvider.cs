using Microsoft.AspNetCore.Http;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using System;
using System.Linq;
using System.Security.Claims;

namespace ShipService.Infrastructure.Core.UserContextProvider
{
    internal class HttpUserContextProvider : IUserContextProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpUserContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserContext GetUserContext()
        {
            if (!(this.httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity claimsIdentity) || claimsIdentity.IsAuthenticated == false)
            {
                return new UserContext();
            }
            var userContext = new UserContext();

            userContext.SetUserContext(
                userId: Guid.Parse(claimsIdentity.Claims.First(c => c.Type.Equals(ClaimTypes.NameIdentifier)).Value),
                username: claimsIdentity.Claims.First(c => c.Type.Equals(ClaimTypes.Name)).Value,
                role: claimsIdentity.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value);

            return userContext;
        }
    }
}
