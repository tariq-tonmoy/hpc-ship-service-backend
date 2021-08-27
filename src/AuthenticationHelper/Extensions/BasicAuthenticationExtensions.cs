using Microsoft.Extensions.DependencyInjection;
using ShipService.Infrastructure.Core.UserContextProvider.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.AuthenticationHelper.Extensions
{
    public static class BasicAuthenticationExtensions
    {
        public static IServiceCollection AddBasicAuthentication(this IServiceCollection services)
        {
            services.AddHttpUserContext();
            services.AddAuthentication(AuthenticateSchemeConstants.BasicAuthenticationScheme)
                .AddScheme<ValidateBasicAuthenticationSchemeOptions, ValidateBasicAuthenticationHandler>(AuthenticateSchemeConstants.BasicAuthenticationScheme, null);
            return services;
        }
    }
}
