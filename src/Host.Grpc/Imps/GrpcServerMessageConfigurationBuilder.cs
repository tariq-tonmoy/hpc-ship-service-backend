using ShipService.Infrastructure.Host.Grpc.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Host.Grpc.Imps
{
    public class GrpcServerMessageConfigurationBuilder : IGrpcMessageConfigurationBuilder
    {
        public IServiceCollection Services { get; protected set; }

        public IEnumerable<GrpcMessageConfigurationOption> Options { get; protected set; }

        public GrpcServerMessageConfigurationBuilder(IServiceCollection services, List<GrpcServerMessageConfigurationOption> options)
        {
            this.Services = services;
            this.Options = options;
        }

        public void Build(IEndpointRouteBuilder endPoints)
        {
            if (this.Options != null && this.Options.Any())
            {
                foreach (GrpcServerMessageConfigurationOption option in this.Options)
                {
                    option.ServiceEndpointBuilder.Invoke(endPoints);
                }
            }
        }
    }
}
