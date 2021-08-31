using ShipService.External.AuthViewModel;
using ShipService.External.Infrastructure.Authentication.Cqrs.Repository.Sqlite;
using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.Cqrs.Repository.Sqlite;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.Extensions;
using ShipService.Infrastructure.Host.Worker.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipService.External.AuthenticationQueryHost.Abstractions;
using ShipService.External.AuthenticationQueryHost.Service.Imps;
using ShipService.Infrastructure.Host.WebApi.Extensions;

namespace ShipService.External.AuthenticationQueryHost
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
            services.AddHttpComponents(needBasicAuthentication: false);
            services.AddScoped<IAuthenticationServiceProvider, AuthenticationServiceProvider>();
            services.AddSqliteRepository()
                    .BuildReadRepository<AuthenticationViewModel, AuthenticationViewModelDbContext>();

            this.services = services;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseHttpPipeline();
            app.UseGrpcServerMessageConfigurations(this.services, this.ConfigureMessageServices);
        }

        private void ConfigureMessageServices(IServiceCollection serviceCollection, IDiscoverServices discoverServices, IMessageConfigurator messageConfigurator)
        {
            var selfServiceId = discoverServices.GetServiceId();
            messageConfigurator.AddMessageServer<AuthQueryService>(selfServiceId, discoverServices, serviceCollection);
        }
    }
}
