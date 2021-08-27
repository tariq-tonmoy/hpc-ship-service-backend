using ShipService.External.NotificationHost.Protos;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Ship.Grpc.Comm.Abstractions;
using ShipService.Infrastructure.Utilities.Abstractions;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Ship.Grpc.Comm
{
    public class NotificationEventPublishService : IPublishEventService<NotificationEvent.NotificationEventClient>
    {
        private readonly NotificationEvent.NotificationEventClient client;
        private readonly IReflectionUtilityProvider reflectionUtility;
        private readonly IPrepareMessageToPublish prepareMessage;

        public NotificationEventPublishService(
            NotificationEvent.NotificationEventClient client,
            IReflectionUtilityProvider reflectionUtility,
            IPrepareMessageToPublish prepareMessage)
        {
            this.client = client;
            this.reflectionUtility = reflectionUtility;
            this.prepareMessage = prepareMessage;
        }

        public async Task PublishMessageAsync<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            var messagePayload = this.prepareMessage.PrepareMessgaePayload(@event);

            await this.client.ApplyEventAsync(new EventModel()
            {
                EventPayload = messagePayload,
                AssemblyName = this.reflectionUtility.GetFullyQualifiedAssemblyName(@event.GetType()),
            });
        }
    }
}
