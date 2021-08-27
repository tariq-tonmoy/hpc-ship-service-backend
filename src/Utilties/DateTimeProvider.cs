using ShipService.Infrastructure.Utilities.Abstractions;
using System;

namespace ShipService.Infrastructure.Utilities
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetUtcDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
