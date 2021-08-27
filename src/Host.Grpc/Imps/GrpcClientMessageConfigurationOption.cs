using ShipService.Infrastructure.Host.Grpc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ShipService.Infrastructure.Host.Grpc.Imps
{
    public class GrpcClientMessageConfigurationOption : GrpcMessageConfigurationOption
    {
        public GrpcClientMessageConfigurationOption(string serviceId)
        {
            this.ServiceId = serviceId;
        }

        public string ServiceUri { get; set; }

        public string ServiceId { get; protected set; }

        public IHttpClientBuilder ClientBuilder { get; set; }
    }
}
