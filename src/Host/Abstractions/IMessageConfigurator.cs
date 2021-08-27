using ShipService.External.ServiceDiscovery.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using ShipService.Infrastructure.Core;

namespace ShipService.Infrastructure.Host.Abstractions
{
    public interface IMessageConfigurator
    {
        void AddMessageClient<TClient>(string serviceId, IDiscoverServices discoverServices, IServiceCollection serviceCollection)
            where TClient : class;

        void AddMessageClient<TClient>(string serviceId, IDiscoverServices discoverServices, IServiceCollection serviceCollection, Type messagePublisherType)
            where TClient : class;

        void AddMessageServer<TService>(string serviceId, IDiscoverServices discoverServices, IServiceCollection serviceCollection)
            where TService : class;
    }
}
