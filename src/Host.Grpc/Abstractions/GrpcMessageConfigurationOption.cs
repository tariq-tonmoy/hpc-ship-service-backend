namespace ShipService.Infrastructure.Host.Grpc.Abstractions
{
    public interface GrpcMessageConfigurationOption : IMessageConfigurationOption
    {
        public string ServiceUri { get; set; }

    }
}
