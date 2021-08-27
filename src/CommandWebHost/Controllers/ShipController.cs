using ShipService.External.AuthenticationQueryHost.Protos;
using ShipService.External.ServiceDiscovery.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Application.Protos;
using ShipService.Application.Commands;

namespace ShipService.Application.CommandWebHost.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShipController : ControllerBase
    {
        private readonly IPublishCommandService<ShipCommand.ShipCommandClient> client;

        public ShipController(IPublishCommandService<ShipCommand.ShipCommandClient> client)
        {
            this.client = client;
        }

        [HttpPost]
        public async Task<IActionResult> AddShips([FromBody] AddShipsCommand command)
        {
            await this.client.PublishMessageAsync(command);
            return this.Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShips([FromBody] UpdateShipsCommand command)
        {
            await this.client.PublishMessageAsync(command);
            return this.Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateShips([FromBody] DeactivateShipsCommand command)
        {
            await this.client.PublishMessageAsync(command);
            return this.Accepted();
        }
    }
}