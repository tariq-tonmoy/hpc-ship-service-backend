using Grpc.Core;
using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Host.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using ShipService.Infrastructure.Core;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ShipService.Infrastructure.Ship.Grpc.Comm;

namespace ShipService.Infrastructure.Host.Grpc.Imps
{
    public class GrpcMessgaeConfigurator : IMessageConfigurator
    {
        private List<GrpcClientMessageConfigurationOption> clientOptions;
        private List<GrpcServerMessageConfigurationOption> serverOptions;

        private void AddMappedGrpcService<T>(IEndpointRouteBuilder endPoints)
            where T : class
        {
            endPoints.MapGrpcService<T>();
        }

        public GrpcMessgaeConfigurator()
        {
            this.clientOptions = new List<GrpcClientMessageConfigurationOption>();
            this.serverOptions = new List<GrpcServerMessageConfigurationOption>();
        }

        public void AddMessageClient<TClient>(string serviceId, IDiscoverServices discoverServices, IServiceCollection serviceCollection)
            where TClient : class
        {
            var serviceUrl = discoverServices.GetServiceUrl(serviceId);
            var clientBuilder = serviceCollection.AddGrpcClient<TClient>(option =>
            {
                option.Address = new Uri(serviceUrl);

                option.ChannelOptionsActions.Add(x => x.Credentials = ChannelCredentials.Insecure);
            });

            clientOptions.Add(new GrpcClientMessageConfigurationOption(serviceId)
            {
                ClientBuilder = clientBuilder,
                ServiceUri = serviceUrl,
            });
        }

        public void AddMessageServer<TService>(string serviceId, IDiscoverServices discoverServices, IServiceCollection serviceCollection)
            where TService : class
        {
            var serviceUrl = discoverServices.GetServiceUrl(serviceId);

            this.serverOptions.Add(new GrpcServerMessageConfigurationOption(serviceId)
            {
                ServiceUri = serviceUrl,
                ServiceEndpointBuilder = AddMappedGrpcService<TService>,
            });
        }

        public List<GrpcClientMessageConfigurationOption> GetGrpcClientMessageConfigurationOptions()
        {
            return this.clientOptions;
        }

        public List<GrpcServerMessageConfigurationOption> GetGrpcServerMessageConfigurationOptions()
        {
            return this.serverOptions;
        }

        public void AddMessageClient<TClient>(string serviceId, IDiscoverServices discoverServices, IServiceCollection serviceCollection, Type messagePublisherType)
            where TClient : class
        {
            this.AddMessageClient<TClient>(serviceId, discoverServices, serviceCollection);

            if (typeof(IPublishCommandBase).IsAssignableFrom(messagePublisherType))
            {
                serviceCollection.AddScoped(typeof(IPublishCommandService<TClient>), messagePublisherType);
            }
            else if (typeof(IPublishEventBase).IsAssignableFrom(messagePublisherType))
            {
                serviceCollection.AddScoped(typeof(IPublishEventService<TClient>), messagePublisherType);
                serviceCollection.AddScoped(typeof(IPublishEventBase), messagePublisherType);
                serviceCollection.TryAddScoped<IPublishEventsAsBulkService, PublishEventAsBulkOnGrpcService>();
            }
        }
    }
}
