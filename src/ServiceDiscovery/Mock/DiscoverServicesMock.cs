using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.External.ServiceDiscovery.Models;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ShipService.External.ServiceDiscovery.Mock
{
    public class DiscoverServicesMock : IDiscoverServices
    {
        private readonly IOptions<ServiceDiscoveryModel> serviceDiscoveryOptions;

        public DiscoverServicesMock(IOptions<ServiceDiscoveryModel> serviceDiscoveryOptions)
        {
            this.serviceDiscoveryOptions = serviceDiscoveryOptions;
        }

        public string[] GetRequiredServices(string ownServiceId)
        {
            return this.serviceDiscoveryOptions?.Value?.RequiredServices?.ToArray();
        }

        public string GetServiceId()
        {
            return this.serviceDiscoveryOptions?.Value?.ServiceId;
        }

        public string GetServiceUrl(string serviceId)
        {
            return this.serviceDiscoveryOptions?
                       .Value?
                       .DiscoveredServices?
                       .FirstOrDefault(x => x.DiscoveredServiceId == serviceId)?
                       .Urls?
                       .FirstOrDefault();
        }
    }
}
