using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;

namespace ShipService.Infrastructure.Core.UserContextProvider
{
    public class MessageUserContextProvider : IUserContextProvider
    {
        private readonly IContextAccessor contextAccessor;

        public MessageUserContextProvider(IContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public UserContext GetUserContext()
        {
            return this.contextAccessor.UserContext;
        }
    }
}
