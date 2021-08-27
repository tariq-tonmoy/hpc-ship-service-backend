using ShipService.ReadSilde.ShipQueryHost.Abstractions;
using ShipService.ReadSilde.ShipQueryHost.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ShipQueryHost.Service.Imps
{
    public class ShipQueryHandler : IQueryHandler
    {
        private readonly IShipQueryRepository repository;

        public ShipQueryHandler(IShipQueryRepository repository)
        {
            this.repository = repository;
        }

        public QueryResponse GetShip(Guid shipId)
        {
            return this.repository.GetShip(shipId);
        }

        public QueryResponse GetShips(ShipQueryModel query)
        {
            return this.repository.GetShips(query);
        }
    }
}
