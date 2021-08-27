using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Host.Abstractions
{
    public interface IPublishEventBase
    {
        Task PublishMessageAsync<TEvent>(TEvent @event)
            where TEvent : DomainEvent;
    }
}
