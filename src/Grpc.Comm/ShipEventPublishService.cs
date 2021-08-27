using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using ShipService.Application.Protos;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Utilities.Abstractions;
using ShipService.Infrastructure.Ship.Grpc.Comm.Abstractions;

namespace ShipService.Infrastructure.Ship.Grpc.Comm
{
    public class ShipEventPublishService : IPublishEventService<ShipEvent.ShipEventClient>
    {
        private readonly ShipEvent.ShipEventClient client;
        private readonly IReflectionUtilityProvider reflectionUtility;
        private readonly IPrepareMessageToPublish prepareMessage;

        public ShipEventPublishService(
            ShipEvent.ShipEventClient client,
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
