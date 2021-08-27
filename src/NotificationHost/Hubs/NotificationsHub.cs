using Microsoft.AspNetCore.SignalR;
using ShipService.External.NotificationHost.Models;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.Infrastructure.Utilities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.NotificationHost.Hubs
{
    public class NotificationsHub : Hub
    {
        private readonly IReadRepository<NotificationClient> readRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public NotificationsHub(IReadRepository<NotificationClient> readRepository, IDateTimeProvider dateTimeProvider)
        {
            this.readRepository = readRepository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

        }

        public async Task Register(Guid correlationId)
        {
            await this.readRepository.SaveAsync(
                new NotificationClient(
                    0,
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    this.dateTimeProvider.GetUtcDateTime(),
                    this.dateTimeProvider.GetUtcDateTime(),
                    false,
                    correlationId,
                    Context.ConnectionId
                ));
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            
            var connections = this.readRepository.GetByFilter(x => x.ClientId == Context.ConnectionId).ToList();
            if (connections != null && connections.Any())
            {
                foreach (var connection in connections)
                {
                    await this.readRepository.DeleteAsync(connection);
                }
            }

        }
    }
}
