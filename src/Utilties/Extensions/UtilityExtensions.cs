using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ShipService.Infrastructure.Utilities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Utilities.Extensions
{
    public static class UtilityExtensions
    {
        public static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IReflectionUtilityProvider, ReflectionUtilityProvider>();
            JsonConvert.DefaultSettings = () => new JsonSerializationSessingsProvider().GetJsonSerializerSettingsForPrivateProperties();
            return services;
        }
    }
}
