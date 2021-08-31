using ShipService.External.AuthenticationQueryHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.AuthenticationQueryHost.Abstractions
{
    public interface IAuthenticationServiceProvider
    {
        QueryResponse Authenticate(AuthQuery query);
    }
}
