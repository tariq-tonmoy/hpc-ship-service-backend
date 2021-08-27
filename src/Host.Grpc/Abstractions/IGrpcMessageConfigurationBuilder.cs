using ShipService.Infrastructure.Host.Abstractions;
using System.Collections.Generic;

namespace ShipService.Infrastructure.Host.Grpc.Abstractions
{
    public interface IGrpcMessageConfigurationBuilder : IMessageConfigurationBuilder
    {
        IEnumerable<GrpcMessageConfigurationOption> Options { get; }
    }
}
