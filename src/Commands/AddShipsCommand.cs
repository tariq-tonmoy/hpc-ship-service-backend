using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;

namespace ShipService.Application.Commands
{
    public class AddShipsCommand : Command
    {
        public AddShipsCommand(IEnumerable<ShipDto> shipsToAdd, UserContext userContext, Guid correlationId)
        {
            this.ShipsToAdd = shipsToAdd;
            this.SetUserContext(userContext);
            this.CorrelationId = correlationId;
        }

        public IEnumerable<ShipDto> ShipsToAdd { get; set; }
    }
}
