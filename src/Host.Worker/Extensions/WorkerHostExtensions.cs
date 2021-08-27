using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.Extensions;
using ShipService.Infrastructure.Host.Grpc.Abstractions;
using ShipService.Infrastructure.Host.Grpc.Imps;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipService.Infrastructure.Core.UserContextProvider.Extensions;
using Microsoft.AspNetCore.Routing;

namespace ShipService.Infrastructure.Host.Worker.Extensions
{
    public static class WorkerHostExtensions
    {
        public static IServiceCollection AddGrpcServerMessageConfigurations(
           this IServiceCollection services)
        {
            services.AddGrpc();
            services.AddSingleton<IMessageConfigurator, GrpcMessgaeConfigurator>();
            services.AddMessageUserContext();
            return services;
        }

        public static IGrpcMessageConfigurationBuilder UseGrpcServerMessageConfigurations(
           this IApplicationBuilder app,
           IServiceCollection services,
           Action<IServiceCollection, IDiscoverServices, IMessageConfigurator> messageConfiguratorAction,
           Action<IEndpointRouteBuilder> configureRouteAction = null)
        {
            GrpcMessgaeConfigurator grpcMessageConfiurator = (GrpcMessgaeConfigurator)app.ApplicationServices.GetRequiredService<IMessageConfigurator>();
            messageConfiguratorAction(services, app.ApplicationServices.GetRequiredService<IDiscoverServices>(), grpcMessageConfiurator);

            var grpcConfigurationBuilder = new GrpcServerMessageConfigurationBuilder(services, grpcMessageConfiurator.GetGrpcServerMessageConfigurationOptions());

            app.UseEndpoints(endpoints =>
                {
                    grpcConfigurationBuilder.Build(endpoints);
                    if (configureRouteAction != null)
                    {
                        configureRouteAction(endpoints);
                    }
                });

            return grpcConfigurationBuilder;
        }

    }
}
