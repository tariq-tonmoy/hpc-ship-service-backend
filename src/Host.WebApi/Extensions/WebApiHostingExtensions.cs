using ShipService.External.ServiceDiscovery.Abstractions;
using ShipService.Infrastructure.AuthenticationHelper;
using ShipService.Infrastructure.Host.Abstractions;
using ShipService.Infrastructure.Host.Extensions;
using ShipService.Infrastructure.Host.Grpc.Abstractions;
using ShipService.Infrastructure.Host.Grpc.Imps;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using ShipService.Infrastructure.AuthenticationHelper.Extensions;

namespace ShipService.Infrastructure.Host.WebApi.Extensions
{
    public static class WebApiHostingExtensions
    {
        public static IServiceCollection AddHttpComponents(this IServiceCollection services, bool needBasicAuthentication = true)
        {
            services.AddMvcCore((options) =>
            {
            })
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            .AddNewtonsoftJson()
            .AddCors();


            services.AddAuthorization();
            if (needBasicAuthentication)
            {
                services.AddBasicAuthentication();
            }
            else
            {
                services.AddAuthentication();
            }

            services.AddHealthChecks();

            return services;
        }

        public static IGrpcMessageConfigurationBuilder AddGrpcClientMessageConfigurations(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IServiceCollection, IDiscoverServices, IMessageConfigurator> messageConfiguratorAction)
        {
            services.AddServiceDiscovery(configuration);
            services.AddSingleton<IMessageConfigurator, GrpcMessgaeConfigurator>();

            var serviceProvider = services.BuildServiceProvider();
            GrpcMessgaeConfigurator grpcMessageConfiurator = (GrpcMessgaeConfigurator)serviceProvider.GetRequiredService<IMessageConfigurator>();

            messageConfiguratorAction(services, serviceProvider.GetRequiredService<IDiscoverServices>(), grpcMessageConfiurator);

            var grpcConfigurationBuilder = new GrpcClientMessageConfigurationBuilder(services, grpcMessageConfiurator.GetGrpcClientMessageConfigurationOptions());

            return grpcConfigurationBuilder;
        }

        public static IApplicationBuilder UseHttpPipeline(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseRouting();

            applicationBuilder.UseCors((corsPolicyBuilder) =>
                   corsPolicyBuilder
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((string origin) => true)
                   .AllowCredentials()
                   .SetPreflightMaxAge(TimeSpan.FromDays(365)));

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");

                endpoints.MapHealthChecks("/health");
            });

            return applicationBuilder;
        }
    }
}
