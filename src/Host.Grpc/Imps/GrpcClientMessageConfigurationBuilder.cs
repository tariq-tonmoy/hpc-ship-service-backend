using ShipService.Infrastructure.Host.Grpc.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Host.Grpc.Imps
{
    public class GrpcClientMessageConfigurationBuilder : IGrpcMessageConfigurationBuilder
    {
        public IServiceCollection Services { get; protected set; }

        public IEnumerable<GrpcMessageConfigurationOption> Options { get; protected set; }

        public GrpcClientMessageConfigurationBuilder(IServiceCollection services, List<GrpcClientMessageConfigurationOption> options)
        {
            this.Services = services;
            this.Options = options;
        }
    }
}
