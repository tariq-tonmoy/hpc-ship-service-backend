using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ShipService.External.NotificationHost.Hubs;
using ShipService.External.NotificationHost.Models;
using ShipService.External.NotificationHost.Protos;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.Infrastructure.Utilities;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ShipService.External.NotificationHost
{
    public class NotificationEventHandlerService : NotificationEvent.NotificationEventBase
    {
        private readonly IReadRepository<NotificationClient> readRepository;
        private readonly IHubContext<NotificationsHub> hubContext;

        public NotificationEventHandlerService(
            IReadRepository<NotificationClient> readRepository,
            IHubContext<NotificationsHub> hubContext)
        {
            this.readRepository = readRepository;
            this.hubContext = hubContext;
        }

        public override async Task<Empty> ApplyEvent(EventModel eventModel, ServerCallContext context)
        {
            var type = System.Type.GetType(eventModel.AssemblyName);
            var method = typeof(JsonConvert)
                                 .GetMethod("DeserializeObject",
                                    BindingFlags.Public | BindingFlags.Static,
                                    new ReflectionBinder(),
                                    new[] { typeof(string) },
                                    null)
                                .MakeGenericMethod(type);

            var @event = (DomainEvent)Convert.ChangeType(method.Invoke(null, new object[] { eventModel.EventPayload }), type);

            var connections = this.readRepository.GetByFilter(x => x.CorrelationId == @event.CorrelationId).ToList();

            if (connections != null && connections.Any())
            {
                foreach (var connection in connections)
                {
                    await this.hubContext.Clients.Client(connection.ClientId).SendAsync("ReceiveEvent", eventModel.EventPayload);
                }
            }


            return new Empty();
        }
    }
}
