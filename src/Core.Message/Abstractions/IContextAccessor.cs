using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Infrastructure.Core.UserContextProvider.Abstractions
{
    public interface IContextAccessor
    {
        UserContext UserContext { get; set; }
    }
}
