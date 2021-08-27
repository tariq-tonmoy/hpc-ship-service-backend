using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.External.ServiceDiscovery.Mock;
using ShipService.External.ServiceDiscovery.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShipService.Infrastructure.Host.Extensions
{
    public static class ServiceDiscoveryExtensions
    {
        public static IServiceCollection AddServiceDiscovery(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ServiceDiscoveryModel>(configuration.GetSection("ServiceDiscovery"));
            services.AddSingleton<IDiscoverServices, DiscoverServicesMock>();

            return services;
        }
    }
}
