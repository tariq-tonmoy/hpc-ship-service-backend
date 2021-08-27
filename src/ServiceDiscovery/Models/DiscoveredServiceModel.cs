using System.Collections.Generic;

namespace ShipService.External.ServiceDiscovery.Models
{
    public class DiscoveredServiceModel
    {
        public string DiscoveredServiceId { get; set; }

        public List<string> Urls { get; set; }
    }
}
