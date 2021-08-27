namespace ShipService.External.ServiceDiscovery.Abstractions
{
    public interface IDiscoverServices
    {
        string GetServiceId();

        string[] GetRequiredServices(string ownServiceId);

        string GetServiceUrl(string serviceId);
    }
}
