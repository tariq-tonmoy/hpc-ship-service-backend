using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ShipService.ReadSilde.ShipQueryHost.Abstractions;
using ShipService.ReadSilde.ShipQueryHost.QueryModels;

namespace ShipService.ReadSilde.ShipQueryHost.Controller
{
    [Authorize(Roles = "User,Admin")]
    [BindProperties(SupportsGet = true)]
    public class QueryController : ControllerBase
    {
        private readonly IQueryHandler queryHandler;

        public QueryController(IQueryHandler queryHandler)
        {
            this.queryHandler = queryHandler;
        }

        [HttpGet]
        public IActionResult GetShips([FromQuery] ShipQueryModel query)
        {
            return this.Ok(this.queryHandler.GetShips(query));
        }

        [HttpGet]
        public IActionResult GetShip([FromQuery] Guid shipId)
        {
            return this.Ok(this.queryHandler.GetShip(shipId));
        }
    }
}
