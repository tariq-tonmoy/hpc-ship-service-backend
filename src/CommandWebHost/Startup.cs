using ShipService.External.AuthenticationQueryHost.Protos;
using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipService.Application.Protos;

using ShipService.Infrastructure.Utilities.Extensions;
using ShipService.Infrastructure.Ship.Grpc.Comm.Extensions;
using ShipService.Infrastructure.Ship.Grpc.Comm;

namespace ShipService.Application.CommandWebHost
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpComponents();
            services.AddGrpcClientMessageConfigurations(configuration, this.ConfigureMessageServices);
            services.AddUtilities();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpPipeline();
        }

        private void ConfigureMessageServices(IServiceCollection serviceCollection, IDiscoverServices discoverServices, IMessageConfigurator messageConfigurator)
        {
            serviceCollection.AddMessagePreparationServices();
            messageConfigurator.AddMessageClient<AuthQuery.AuthQueryClient>("AuthenticationQueryHost", discoverServices, serviceCollection);
            messageConfigurator.AddMessageClient<ShipCommand.ShipCommandClient>("CommandWorkerHost", discoverServices, serviceCollection, typeof(ShipCommandPublishService));
        }
    }
}
