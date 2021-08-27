using System;

namespace ShipService.Infrastructure.Utilities.Abstractions
{
    public interface IReflectionUtilityProvider
    {
        string GetFullyQualifiedAssemblyName(Type type);
    }
}
