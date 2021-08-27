using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using System.Threading;

namespace ShipService.Infrastructure.Core.UserContextProvider.ContextAccessors
{
    internal class MessageContextAccessor : IContextAccessor
    {
        private static readonly AsyncLocal<SecurityContext> _currentSecurityContext = new AsyncLocal<SecurityContext>();

        public UserContext? UserContext
        {
            get
            {
                return _currentSecurityContext.Value?.UserContext;
            }
            set
            {
                var holder = _currentSecurityContext.Value;
                if (holder != null)
                {
                    // Clear current UserContext trapped in the AsyncLocals, as its done.
                    holder.UserContext = null;
                }

                if (value != null)
                {
                    // Use an object indirection to hold the UserContext in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _currentSecurityContext.Value = new SecurityContext(value);
                }
            }
        }
    }
}
