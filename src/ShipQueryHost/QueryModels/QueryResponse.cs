using ShipService.ReadSilde.ViewModels;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ShipQueryHost.QueryModels
{
    public class QueryResponse
    {
        public IEnumerable<QueryResponsePayload> ResponsePayloads { get; set; }

        public long Count { get; set; }
    }
}
