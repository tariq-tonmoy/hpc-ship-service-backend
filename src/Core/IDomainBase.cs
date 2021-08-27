using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Core
{
    public interface IDomainBase
    {
        Guid DomainId { get; }
    }
}
