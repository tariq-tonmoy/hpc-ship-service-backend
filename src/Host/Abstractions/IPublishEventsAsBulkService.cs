using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Host.Abstractions
{
    public interface IPublishEventsAsBulkService
    {
        Task PublishBulkEvents<TEvent>(IEnumerable<TEvent> events)
            where TEvent : DomainEvent;
    }
}
