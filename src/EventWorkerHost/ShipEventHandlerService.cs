using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ShipService.Application.Protos;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.Abstractions;
using ShipService.Infrastructure.Utilities;
using static ShipService.Application.Protos.ShipEvent;

namespace ShipService.ReadSilde.EventWebHost
{
    public class ShipEventHandlerService : ShipEventBase
    {
        private readonly IEventHandlingOrchestrator orchestrator;
        public ShipEventHandlerService(IEventHandlingOrchestrator orchestrator)
        {
            this.orchestrator = orchestrator;
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

            var command = (DomainEvent)Convert.ChangeType(method.Invoke(null, new object[] { eventModel.EventPayload }), type);

            orchestrator.InitiateEventHandling(command);
            return new Empty();
        }
    }
}
