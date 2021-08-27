using ShipService.Infrastructure.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;

namespace ShipService.Infrastructure.Core.Service.Imps
{
    public abstract class MessageHandlingOrchestratorHelper
    {
        public MessageHandlingOrchestratorHelper(IContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        private const string HandlerMethodName = "HandleAsync";
        private readonly IContextAccessor contextAccessor;

        protected async Task HandleCommandReceivedEventAsync<TMessage>(TMessage message, IServiceScope scope)
            where TMessage : IMessage
        {
            contextAccessor.UserContext = message.UserContext;

            var messageType = message.GetType();
            var handlerType = message is Command ? typeof(IAsyncCommandHandler<>).MakeGenericType(messageType) : typeof(IAsyncEventHandler<>).MakeGenericType(messageType);
            var handler = scope.ServiceProvider.GetService(handlerType);
            if (handler != null)
            {
                var response = (Task)handler.GetType().GetMethod(HandlerMethodName)?.Invoke(handler, new object[] { message });
                if (response != null)
                {
                    await response;
                }
            }
        }
    }
}
