using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.AuthenticationQueryHost.Models
{
    public class QueryResponse
    {
        public bool IsAuthenticated { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }
    }
}
