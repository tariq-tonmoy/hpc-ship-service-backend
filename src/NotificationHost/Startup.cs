using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.Extensions;
using ShipService.Infrastructure.Host.Worker.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipService.Infrastructure.Utilities.Extensions;
using Microsoft.AspNetCore.Routing;
using ShipService.External.NotificationHost.Hubs;
using ShipService.External.NotificationHost.Models;
using ShipService.External.NotificationHost.Repository;
using System;

namespace ShipService.External.NotificationHost
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
            services.AddMvcCore().AddCors();
            services.AddServiceDiscovery(configuration);
            services.AddGrpcServerMessageConfigurations();
            services.AddUtilities();
            services.AddSignalR();
            services.AddSqliteRepository()
                    .BuildReadRepository<NotificationClient, NotificationDbContext>();

            this.services = services;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseCors((corsPolicyBuilder) =>
                   corsPolicyBuilder
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((string origin) => true)
                   .AllowCredentials()
                   .SetPreflightMaxAge(TimeSpan.FromDays(365)));
            app.UseGrpcServerMessageConfigurations(this.services, this.ConfigureMessageServices, this.ConfigureRouteAction);
        }

        private void ConfigureRouteAction(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<NotificationsHub>("/hubs");
        }

        private void ConfigureMessageServices(IServiceCollection serviceCollection, IDiscoverServices discoverServices, IMessageConfigurator messageConfigurator)
        {
            var selfServiceId = discoverServices.GetServiceId();
            messageConfigurator.AddMessageServer<NotificationEventHandlerService>(selfServiceId, discoverServices, serviceCollection);
        }
    }
}
