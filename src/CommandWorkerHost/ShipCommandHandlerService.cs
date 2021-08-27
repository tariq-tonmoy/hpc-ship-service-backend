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
using static ShipService.Application.Protos.ShipCommand;

namespace ShipService.Application.CommandWorkerHost
{
    public class ShipCommandHandlerService : ShipCommandBase
    {
        private readonly ICommandHandlingOrchestrator orchestrator;

        public ShipCommandHandlerService(ICommandHandlingOrchestrator orchestrator)
        {
            this.orchestrator = orchestrator;
        }

        public override async Task<Empty> ApplyCommand(CommandModel commandModel, ServerCallContext context)
        {
            var type = System.Type.GetType(commandModel.AssemblyName);
            var method = typeof(JsonConvert)
                                 .GetMethod("DeserializeObject",
                                    BindingFlags.Public | BindingFlags.Static,
                                    new ReflectionBinder(),
                                    new[] { typeof(string) },
                                    null)
                                .MakeGenericMethod(type);

            var command = (Command)Convert.ChangeType(method.Invoke(null, new object[] { commandModel.CommandPayload }), type);

            orchestrator.InitiateCommandHandling(command);
            return new Empty();
        }
    }
}
