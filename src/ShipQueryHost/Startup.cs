using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Host.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipService.Infrastructure.Host.WebApi.Extensions;
using ShipService.External.AuthenticationQueryHost.Protos;
using ShipService.ReadSilde.ShipQueryHost.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite;
using ShipService.ReadSilde.ShipQueryHost.Service.Imps;

namespace ShipService.ReadSilde.ShipQueryHost
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
            services.AddSingleton<IDbConnectionSettingsProvider, SqliteDbConnectionSettingsProvider>();

            services.AddEntityFrameworkSqlite().AddDbContext<ShipViewModelDbContext>();
            services.AddScoped<IShipQueryRepository, ShipQueryRepository>();
            services.AddScoped<IQueryHandler, ShipQueryHandler>();
            services.AddSingleton<IDbConnectionSettingsProvider, SqliteDbConnectionSettingsProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpPipeline();
        }

        private void ConfigureMessageServices(IServiceCollection serviceCollection, IDiscoverServices discoverServices, IMessageConfigurator messageConfigurator)
        {
            messageConfigurator.AddMessageClient<AuthQuery.AuthQueryClient>("AuthenticationQueryHost", discoverServices, serviceCollection);
        }
    }
}
