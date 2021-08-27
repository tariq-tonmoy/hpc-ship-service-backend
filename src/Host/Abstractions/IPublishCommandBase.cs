using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Host.Abstractions
{
    public interface IPublishCommandBase
    {
        Task PublishMessageAsync<TCommand>(TCommand command)
            where TCommand : Command;
    }
}
