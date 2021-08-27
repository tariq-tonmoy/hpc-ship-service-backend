using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;

namespace ShipService.Application.Commands
{
    public class DeactivateShipsCommand : Command
    {
        public DeactivateShipsCommand(List<DeactivateShipDto> shipsToDeactivate, UserContext userContext, Guid correlationId)
        {
            this.ShipsToDeactivate = shipsToDeactivate;
            this.CorrelationId = correlationId;
            this.SetUserContext(userContext);
        }

        public List<DeactivateShipDto> ShipsToDeactivate { get; set; }
    }
}
