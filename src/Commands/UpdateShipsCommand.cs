using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;

namespace ShipService.Application.Commands
{
    public class UpdateShipsCommand : Command
    {
        public UpdateShipsCommand(List<ShipDto> shipsToUpdate, UserContext userContext, Guid correlationId)
        {
            this.ShipsToUpdate = shipsToUpdate;
            this.CorrelationId = correlationId;
            this.SetUserContext(userContext);
        }

        public List<ShipDto> ShipsToUpdate { get; set; }
    }
}
