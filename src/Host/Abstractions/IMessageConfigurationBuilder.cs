using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Host.Abstractions
{
    public interface IMessageConfigurationBuilder
    {
        IServiceCollection Services { get; }
    }
}
