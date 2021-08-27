using ShipService.Infrastructure.Utilities.Abstractions;
using System;

namespace ShipService.Infrastructure.Utilities
{
    internal class ReflectionUtilityProvider : IReflectionUtilityProvider
    {
        public string GetFullyQualifiedAssemblyName(Type type)
        {
            return type.AssemblyQualifiedName;
        }
    }
}
