using ShipService.Infrastructure.Core.Abstractions;
using ShipService.Infrastructure.Core.Service.Imps;
using Microsoft.Extensions.DependencyInjection;

namespace ShipService.Infrastructure.Core.Message.Extensions
{
    public static class MessageHandlerExtensions
    {
        public static IMessageHandlerBuilder AddMessageHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandlingOrchestrator, CommandHandlingOrchestrator>();
            services.AddTransient<IEventHandlingOrchestrator, EventHandlingOrchestrator>();
            IMessageHandlerBuilder builder = new MessageHandlerBuilder(services);

            return builder;
        }
    }
}
