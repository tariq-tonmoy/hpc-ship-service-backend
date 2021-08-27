using System.Collections.Generic;

namespace ShipService.External.ServiceDiscovery.Models
{
    public class ServiceDiscoveryModel
    {
        public string ServiceId { get; set; }

        public string ServiceUrl { get; set; }

        public List<string> RequiredServices { get; set; }

        public List<DiscoveredServiceModel> DiscoveredServices { get; set; }
    }
}
