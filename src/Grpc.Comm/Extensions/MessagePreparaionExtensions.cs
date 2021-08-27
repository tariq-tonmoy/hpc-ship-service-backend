using Microsoft.Extensions.DependencyInjection;
using ShipService.Infrastructure.Ship.Grpc.Comm.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Ship.Grpc.Comm.Extensions
{
    public static class MessagePreparaionExtensions
    {
        public static IServiceCollection AddMessagePreparationServices(this IServiceCollection services)
        {
            services.AddSingleton<IPrepareMessageToPublish, PrepareMessageToPublish>();
            return services;
        }
    }
}
