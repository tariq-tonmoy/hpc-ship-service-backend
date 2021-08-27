using ShipService.Infrastructure.Host.Grpc.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ShipService.Infrastructure.Host.Grpc.Imps
{
    public class GrpcServerMessageConfigurationOption : GrpcMessageConfigurationOption
    {
        public GrpcServerMessageConfigurationOption(string serviceId)
        {
            this.ServiceId = serviceId;
        }

        public string ServiceUri { get; set; }

        public string ServiceId { get; protected set; }

        public Action<IEndpointRouteBuilder> ServiceEndpointBuilder { get; set; }
    }
}
