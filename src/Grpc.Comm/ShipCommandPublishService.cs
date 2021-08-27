using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using ShipService.Application.Protos;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Utilities.Abstractions;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using ShipService.Infrastructure.Ship.Grpc.Comm.Abstractions;

namespace ShipService.Infrastructure.Ship.Grpc.Comm
{
    public class ShipCommandPublishService : IPublishCommandService<ShipCommand.ShipCommandClient>
    {
        private readonly ShipCommand.ShipCommandClient client;
        private readonly IReflectionUtilityProvider reflectionUtility;
        private readonly IPrepareMessageToPublish prepareMessage;

        public ShipCommandPublishService(
            ShipCommand.ShipCommandClient client,
            IReflectionUtilityProvider reflectionUtility,
            IPrepareMessageToPublish prepareMessage)
        {
            this.client = client;
            this.reflectionUtility = reflectionUtility;
            this.prepareMessage = prepareMessage;
        }


        public async Task PublishMessageAsync<TCommand>(TCommand command) where TCommand : Command
        {
            var messagePayload = this.prepareMessage.PrepareMessgaePayload(command);

            await this.client.ApplyCommandAsync(new CommandModel()
            {
                CommandPayload = messagePayload,
                AssemblyName = this.reflectionUtility.GetFullyQualifiedAssemblyName(command.GetType()),
            });
        }
    }
}
