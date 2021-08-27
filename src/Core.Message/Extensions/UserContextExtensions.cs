using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using ShipService.Infrastructure.Core.UserContextProvider.ContextAccessors;
using System.Linq;

namespace ShipService.Infrastructure.Core.UserContextProvider.Extensions
{
    public static class UserContextExtensions
    {
        public static IServiceCollection AddHttpUserContext(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            if (services.All(service => service.ServiceType != typeof(IUserContextProvider)))
            {
                services.AddSingleton<IUserContextProvider, HttpUserContextProvider>();
            }
            return services;
        }

        public static IServiceCollection AddMessageUserContext(this IServiceCollection services)
        {
            services.TryAddSingleton<IContextAccessor, MessageContextAccessor>();
            if (services.All(service => service.ServiceType != typeof(IUserContextProvider)))
            {
                services.AddSingleton<IUserContextProvider, MessageUserContextProvider>();
            }
            return services;
        }
    }
}
