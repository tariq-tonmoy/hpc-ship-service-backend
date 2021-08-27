using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipService.Infrastructure.Host.Worker.Extensions;
using ShipService.Infrastructure.Utilities.Extensions;
using ShipService.Infrastructure.Core.Message.Extensions;
using ShipService.ReadSilde.EventHandlers;
using ShipService.Domain.ShipEvents;
using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using ShipService.ReadSilde.ViewModels;
using ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite;
using ShipService.ReadSilde.ViewModels.Abstractions;

namespace ShipService.ReadSilde.EventWebHost
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
            services.AddUtilities();
            services.AddMessageHandlers()
                    .AddEventHandler<ShipCreatedEvent>(typeof(ShipCreatedEventHandler))
                    .AddEventHandler<ShipUpdatedEvent>(typeof(ShipUpdatedEventHandler))
                    .AddEventHandler<ShipDeactivatedEvent>(typeof(ShipDeactivatedEventHandler));

            services.AddSqliteRepository()
                    .BuildReadRepository<ShipViewModel, ShipViewModelDbContext>();

            services.AddSingleton<IShipViewModelGeneratorService, ShipViewModelGeneratorService>();

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
            messageConfigurator.AddMessageServer<ShipEventHandlerService>(selfServiceId, discoverServices, serviceCollection);
        }

    }
}
