using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.Extensions;
using ShipService.Infrastructure.Host.Worker.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipService.Application.Protos;

using ShipService.Infrastructure.Host.WebApi.Extensions;
using ShipService.Infrastructure.Utilities.Extensions;
using ShipService.Infrastructure.Core.Message.Extensions;
using ShipService.Application.Commands;
using ShipService.Application.CommandHandlers;
using ShipService.Infrastructure.Core.UserContextProvider.Extensions;
using ShipService.Infrastructure.Ship.Grpc.Comm.Extensions;
using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using ShipService.Domain.ShipAggregateRoot;
using ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite;
using ShipService.Infrastructure.Ship.Grpc.Comm;
using ShipService.External.NotificationHost.Protos;

namespace ShipService.Application.CommandWorkerHost
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private IServiceCollection services;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceDiscovery(configuration);
            services.AddGrpcServerMessageConfigurations();
            services.AddGrpcClientMessageConfigurations(configuration, this.ConfigureClientMessageServices);
            services.AddUtilities();
            services.AddMessageHandlers()
                    .AddCommandHandler<AddShipsCommand>(typeof(AddShipsCommandHandler))
                    .AddCommandHandler<UpdateShipsCommand>(typeof(UpdateShipsCommandHandler))
                    .AddCommandHandler<DeactivateShipsCommand>(typeof(DeactivateShipsCommandHandler));

            services.AddSqliteRepository()
                    .BuildAggregateRootRepository<ShipAggregateRoot, ShipAggregateRootDbContext>();

            this.services = services;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseGrpcServerMessageConfigurations(this.services, this.ConfigureServerMessageServices);
        }

        private void ConfigureServerMessageServices(IServiceCollection serviceCollection, IDiscoverServices discoverServices, IMessageConfigurator messageConfigurator)
        {
            var selfServiceId = discoverServices.GetServiceId();
            messageConfigurator.AddMessageServer<ShipCommandHandlerService>(selfServiceId, discoverServices, serviceCollection);
        }

        private void ConfigureClientMessageServices(IServiceCollection serviceCollection, IDiscoverServices discoverServices, IMessageConfigurator messageConfigurator)
        {
            serviceCollection.AddMessagePreparationServices();
            messageConfigurator.AddMessageClient<ShipEvent.ShipEventClient>("EventWorkerHost", discoverServices, serviceCollection, typeof(ShipEventPublishService));
            messageConfigurator.AddMessageClient<NotificationEvent.NotificationEventClient>("NotificationHost", discoverServices, serviceCollection, typeof(NotificationEventPublishService));
        }
    }
}
