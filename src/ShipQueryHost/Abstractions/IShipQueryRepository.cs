using ShipService.ReadSilde.ShipQueryHost.QueryModels;
using ShipService.ReadSilde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ShipQueryHost.Abstractions
{
    public interface IShipQueryRepository
    {
        public QueryResponse GetShips(ShipQueryModel query);

        public QueryResponse GetShip(Guid shipId);
    }
}
