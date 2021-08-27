using Newtonsoft.Json;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using ShipService.Infrastructure.Ship.Grpc.Comm.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Ship.Grpc.Comm
{
    public class PrepareMessageToPublish : IPrepareMessageToPublish
    {
        private readonly IUserContextProvider userContextProvider;

        public PrepareMessageToPublish(IUserContextProvider userContextProvider)
        {
            this.userContextProvider = userContextProvider;
        }

        public string PrepareMessgaePayload<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            var userContext = this.userContextProvider.GetUserContext();
            message.SetUserContext(userContext);
            var messagePayload = JsonConvert.SerializeObject(message);
            return messagePayload;
        }
    }
}
